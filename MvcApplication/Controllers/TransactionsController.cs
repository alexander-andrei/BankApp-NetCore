using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Context;
using MvcApplication.Bundles.Core.Entity;
using MvcApplication.Bundles.Transactions.Api;
using MvcApplication.Bundles.Transactions.Context;
using MvcApplication.Bundles.Transactions.Entity;
using MvcApplication.Bundles.Transactions.Services;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ConnectionConfiguration _confgurations;

        public TransactionsController(IOptions<ConnectionConfiguration> subOptionsAccessor)
        {
            _confgurations = subOptionsAccessor.Value;
        }

        public RedirectToActionResult Index(int userId)
        {
            User curentUser = null;

            // get user
            using (var userCtx = new UserDbContext(_confgurations.ConnectionString))
            {
                var users = userCtx.Users.Where(u => u.Id == userId).ToList();
                foreach (var user in users)
                {
                    curentUser = user;
                }
            }

            if (curentUser == null)
            {
                return null;
            }

            // create beneficiary
            // THIS IS A TEST DATA CLASS
            var beneficiary = new Beneficiary()
            {
                Name = "Ben",
                Surname = "Eficiary",
                Account = "19321234521",
                TransferredSum = 1241.23
            };

            // check if user has enough money
            if (beneficiary.TransferredSum > curentUser.Ballance)
            {
                return null;
            }

            // Find Beneficiary bank
            var benId = new BankLocator().GetUserBank(beneficiary.Account);

            // Set Beneficiary bank id
            beneficiary.BankId = benId;

            // create transaction
            var transaction = new Transaction()
            {
                Information = "some info that does not exist",
                ActiveBankId = beneficiary.BankId,
                BeneficiaryId = beneficiary.Id,
                UserId = curentUser.Id
            };

            // send transaction to bank
            var activeBankContext = new ActiveBankDbContext(_confgurations.ConnectionString);
            var apiTransaction = new BankApi(beneficiary.BankId, activeBankContext, beneficiary).MakeTransaction();

            // check if transaction was ok
            if (!apiTransaction)
            {
                return null;
            }

            // save beneficiary details in db
            using (var benCtx = new BeneficiaryDbContext(_confgurations.ConnectionString))
            {
                benCtx.Beneficiaries.Add(beneficiary);
                benCtx.SaveChanges();
            }

            // save transaction details in db
            using (var transactionCtx = new TransactionDbContext(_confgurations.ConnectionString))
            {
                transactionCtx.Transactions.Add(transaction);
                transactionCtx.SaveChanges();
            }

            curentUser.Ballance = curentUser.Ballance - beneficiary.TransferredSum;

            // save user ballance
            using (var userCtx = new UserDbContext(_confgurations.ConnectionString))
            {
                userCtx.Entry(curentUser).State = EntityState.Modified;
                userCtx.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}