using System;
using System.Collections.Generic;
using System.Linq;
using MvcApplication.Bundles.Core.Services.Manager;
using MvcApplication.Bundles.Payments.Context;
using MvcApplication.Bundles.Payments.Entity;

namespace MvcApplication.Bundles.Payments.Services
{
    public class PaymentsManager : BaseManager<Payment>
    {
        public PaymentsManager(string connectionString) : base(connectionString)
        {
        }

        public override List<Payment> GetAll(int id = 0)
        {
            List<Payment> payments;

            try
            {
                using (var paymentCtx = new PaymentDbContext(GetConnectionString()))
                {
                    payments = paymentCtx.Payments.Where(p => p.UserId == id).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return payments;
        }

        public void DownloadPdfPayment(int paymentId)
        {
            Payment payment;
            using (var paymentCtx = new PaymentDbContext("test"))
            {
                payment = paymentCtx.Payments.Where(p => p.Id == paymentId).ToList().First();
            }

            if (payment == null)
            {
                throw new Exception("No payment was found");
            }

            // TODO: make logic to download payment
        }
    }
}