using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Context;
using MvcApplication.Bundles.Core.Entity;
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

            // create beneficiary
            var beneficiary = new Beneficiary()
            {
                Name = "Ben",
                Surname = "Eficiary",
                Account = "19321234521",
                TransferredSum = 1241.23
            };

            // LOGIC TO FIN USER BY ACCOUNT NUMBER

            // connect to beneficiary bank


            // create transaction
            // validate transaction
            // send transaction to bank
            // check if transaction was ok
            // save user ballance
            // save transaction details in db

            return View();
        }
    }
}
