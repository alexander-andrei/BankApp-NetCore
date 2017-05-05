using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcApplication.Bundles.CreditCardInformation.Context;
using MvcApplication.Bundles.CreditCardInformation.Entity;
using MvcApplication.Config.Users;

namespace MvcApplication.Controllers
{
    public class CreditCardInformationController : Controller
    {
        private readonly string _connectionString;

        public CreditCardInformationController(ConnectionConfiguration configuration)
        {
            _connectionString = configuration.ConnectionString;
        }

        public ViewResult Index()
        {
            return View();
        }

        public void ChangePinNumber(int creditCardId, string pinNumber)
        {
            try
            {
                var cc = GetCreditCard(creditCardId);
                cc.PinNumber = pinNumber;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Manage3DSecure(int creditCardId, bool status)
        {
            try
            {
                var cc = GetCreditCard(creditCardId);
                cc.Security3D = status;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private CreditCard GetCreditCard(int creditCardId)
        {
            CreditCard creditCard = null;
            using (var userCtx = new CreditCardDbContext(_connectionString))
            {
                var users = userCtx.CreditCards.Where(cc => cc.Id == creditCardId).ToList();
                foreach (var user in users)
                {
                    creditCard = user;
                }
            }

            if (creditCard == null)
            {
                throw new Exception("No credit card was found");
            }

            return creditCard;
        }
    }
}