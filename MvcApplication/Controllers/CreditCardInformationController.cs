using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.CreditCardInformation.Context;
using MvcApplication.Bundles.CreditCardInformation.Entity;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class CreditCardInformationController : Controller
    {
        private readonly string _connectionString;

        public CreditCardInformationController(IOptions<ConnectionConfiguration> configuration)
        {
            _connectionString = configuration.Value.ConnectionString;
        }

        public ViewResult Index(int id)
        {
            List<CreditCard> creditCards;
            using (var ccCtx = new CreditCardDbContext(_connectionString))
            {
                creditCards = ccCtx.CreditCards.Where(cc => cc.UserId == id).ToList();
            }

            return View(creditCards);
        }

        public void ChangePinNumber(int creditCardId, string pinNumber)
        {
            try
            {
                using (var userCtx = new CreditCardDbContext(_connectionString))
                {
                    var creditCard = userCtx.CreditCards.Where(cc => cc.Id == creditCardId).ToList().First();

                    creditCard.PinNumber = pinNumber;
                    userCtx.SaveChanges();
                }
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
                using (var userCtx = new CreditCardDbContext(_connectionString))
                {
                    var creditCard = userCtx.CreditCards.Where(cc => cc.Id == creditCardId).ToList().First();

                    creditCard.Security3D = status;
                    userCtx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}