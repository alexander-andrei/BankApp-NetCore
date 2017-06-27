using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Context;
using MvcApplication.Bundles.Core.Entity;
using MvcApplication.Bundles.Core.Services;
using MvcApplication.Bundles.Transactions.Api;
using MvcApplication.Bundles.Transactions.Entity;
using MvcApplication.Bundles.Transactions.Services;
using MvcApplication.Config.Connection;
using Microsoft.AspNetCore.Http;

namespace MvcApplication.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly string _connectionString;

        private readonly UserManager _userManager;
        private readonly BeneficiaryManager _beneficiaryManager;
        private readonly TransactionManager _transactionManager;
        private readonly AuthenticationManager _authenticationManager;

        public TransactionsController(IOptions<ConnectionConfiguration> connection)
        {
            _connectionString = connection.Value.ConnectionString;

            _userManager = new UserManager(_connectionString);
            _beneficiaryManager = new BeneficiaryManager(_connectionString);
            _transactionManager = new TransactionManager(_connectionString);
            _authenticationManager = new AuthenticationManager(_userManager);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var key = HttpContext.Session.GetInt32(AuthenticationManager.UserIdKey);
            var auth = _authenticationManager.CheckIfUserIsAuthorized(key);

            if (auth == false)
            {
                return RedirectToAction("Index", "Authentication");
            }
            
            return View();
        }

        [HttpPost]
        public RedirectToActionResult DoTransaction(int userId, string name, string surname, string accountNo, double value)
        {
            var curentUser = _userManager.GetAll(userId).First();

            // create beneficiary
            var beneficiary = new Beneficiary()
            {
                Name = name,
                Surname = surname,
                Account = accountNo,
            };

            // check if user has enough money
            if (value > curentUser.Ballance)
            {
                throw new Exception("User does not have enuf money");
            }

            // Find Beneficiary bank
            var benBankId = new BankLocator().GetUserBank(beneficiary.Account);

            // Set Beneficiary bank id
            beneficiary.BankId = benBankId;

            // create transaction
            var transaction = new Transaction()
            {
                Information = "some info that does not exist",
                ActiveBankId = beneficiary.BankId,
                BeneficiaryId = beneficiary.Id,
                UserId = curentUser.Id,
                TransferedValue = value
            };

            // send transaction to bank
            var activeBankContext = new ActiveBankDbContext(_connectionString);
            new BankApi(beneficiary.BankId, activeBankContext, beneficiary).MakeTransaction();

            // save beneficiary details in db
            _beneficiaryManager.SaveBeneficiary(beneficiary);

            // save transaction details in db
            _transactionManager.SaveTransaction(transaction);

           curentUser.Ballance = curentUser.Ballance - value;

            // save user ballance
            _userManager.UpdateUser(curentUser);

            return RedirectToAction("Index", "Home");
        }
    }
}