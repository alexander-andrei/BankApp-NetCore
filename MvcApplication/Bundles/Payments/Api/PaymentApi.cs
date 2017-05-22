using MvcApplication.Bundles.Core.Api.Response;
using MvcApplication.Bundles.Payments.Api.Response;
using MvcApplication.Bundles.Payments.Entity;
using MvcApplication.Bundles.Payments.Services;
using Newtonsoft.Json;

namespace MvcApplication.Bundles.Payments.Api
{
    public class PaymentApi
    {
        private readonly PaymentsManager _paymentsManager;
        private readonly StatusCodes _statusCodes;

        public PaymentApi(PaymentsManager paymentsManager, StatusCodes statusCodes)
        {
            _paymentsManager = paymentsManager;
            _statusCodes = statusCodes;
        }

        public string CreatePayment(Payment payment)
        {
            var status = _paymentsManager.CreatePayment(payment);

            var response = new CreatedPaymentResponse
            {
                StatusCode = _statusCodes.GetStatusCode(status),
                Message = "Payment created succesfully ."
            };

            return JsonConvert.SerializeObject(response);
        }
    }
}