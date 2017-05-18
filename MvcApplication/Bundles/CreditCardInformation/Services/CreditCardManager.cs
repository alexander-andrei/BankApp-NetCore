using System;
using System.Collections.Generic;
using System.Linq;
using MvcApplication.Bundles.CreditCardInformation.Context;
using MvcApplication.Bundles.CreditCardInformation.Entity;

namespace MvcApplication.Bundles.CreditCardInformation.Services
{
    public class CreditCardManager
    {
        private readonly string _connectionString;

        public CreditCardManager(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<CreditCard> GetUserCreditCards(int id)
        {
            List<CreditCard> creditCards;
            using (var ccCtx = new CreditCardDbContext(_connectionString))
            {
                creditCards = ccCtx.CreditCards.Where(cc => cc.UserId == id).ToList();
            }

            return creditCards;
        }

        public void ChangeCardPin(int creditCardId, string pinNumber)
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

        public void Change3dSecureStatus(int creditCardId, bool status)
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