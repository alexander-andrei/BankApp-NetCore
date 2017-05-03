using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Context;
using MvcApplication.Bundles.Core.Entity;
using MvcApplication.Bundles.Transactions.Api;
using MvcApplication.Bundles.Transactions.Entity;
using MvcApplication.Bundles.Transactions.Services;
using MvcApplication.Config.Users;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConnectionConfiguration _confgurations;

        public HomeController(IOptions<ConnectionConfiguration> subOptionsAccessor)
        {
            _confgurations = subOptionsAccessor.Value;
        }

        public ViewResult Index()
        {
            var userId = 1;
            User curentUser = null;

            // get user
            using (var context = new UserDbContext(_confgurations.ConnectionString))
            {
                var users = context.Users.Where(u => u.Id == userId).ToList();
                foreach (var user in users)
                {
                    curentUser = user;
                }
            }

            // create beneficiary
            var beneficiary = new Beneficiary()
            {
                Name = "Ben",
                Surname = "Eficiary",
                Account = "19321234521",
                TransferredSum = 1241.23
            };

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
            var benBankApi = new BankApi(beneficiary.BankId, activeBankContext, beneficiary).MakeTransaction();

            // check if transaction was ok

            // save transaction details in db
            // save user ballance

            return View();
        }
    }
}
