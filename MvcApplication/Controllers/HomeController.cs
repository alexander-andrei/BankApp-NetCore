using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Context;
using MvcApplication.Bundles.Core.Entity;
using MvcApplication.Bundles.Transactions.Api;
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

            if (curentUser == null)
            {
                throw new Exception("User was not found");
            }

            // LOGIC TO FIN USER'S BANK BY ACCOUNT NUMBER

            // create beneficiary
            var beneficiary = new Beneficiary()
            {
                Name = "Ben",
                Surname = "Eficiary",
                Account = "19321234521",
                TransferredSum = 1241.23,
                BankId = 1
            };


            // create transaction
            // validate transaction
            // send transaction to bank
            try
            {
                var activeBankDbContext = new ActiveBankDbContext(_confgurations.ConnectionString);
                var bankData = new BankData(beneficiary.Id, activeBankDbContext);
                var beneficiaryBank = bankData.MakeTransaction();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            // check if transaction was ok
            // save user ballance
            // save transaction details in db

            return View();
        }
    }
}
