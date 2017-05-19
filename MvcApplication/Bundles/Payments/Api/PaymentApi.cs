using Microsoft.AspNetCore.Mvc;
using MvcApplication.Bundles.Payments.Entity;
using MvcApplication.Bundles.Payments.Services;

namespace MvcApplication.Bundles.Payments.Api
{
    public class PaymentApi
    {
        private readonly PaymentsManager _paymentsManager;

        public PaymentApi(PaymentsManager paymentsManager)
        {
            _paymentsManager = paymentsManager;
        }

        public void CreatePayment(Payment payment)
        {
            _paymentsManager.CreatePayment(payment);

            // TODO: IMPLEMENT JSON RESPONSE
        }
    }
}