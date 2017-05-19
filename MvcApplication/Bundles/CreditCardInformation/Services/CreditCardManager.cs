using System;
using System.Collections.Generic;
using System.Linq;
using MvcApplication.Bundles.Core.Services.Manager;
using MvcApplication.Bundles.CreditCardInformation.Context;
using MvcApplication.Bundles.CreditCardInformation.Entity;

namespace MvcApplication.Bundles.CreditCardInformation.Services
{
    public class CreditCardManager : BaseManager<CreditCard>
    {
        public CreditCardManager(string connectionString) : base(connectionString)
        {
        }

        public override List<CreditCard> GetAll(int id = 0)
        {
            List<CreditCard> creditCards;

            try
            {
                using (var ccCtx = new CreditCardDbContext(GetConnectionString()))
                {
                    creditCards = ccCtx.CreditCards.Where(cc => cc.UserId == id).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return creditCards;
        }

        public void ChangeCardPin(int creditCardId, string pinNumber)
        {
            try
            {
                using (var userCtx = new CreditCardDbContext(GetConnectionString()))
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

        public void Change3DSecureStatus(int creditCardId, bool status)
        {
            try
            {
                using (var userCtx = new CreditCardDbContext(GetConnectionString()))
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