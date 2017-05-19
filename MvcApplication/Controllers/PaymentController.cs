using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Services;
using MvcApplication.Bundles.Payments.Api;
using MvcApplication.Bundles.Payments.Entity;
using MvcApplication.Bundles.Payments.Services;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PaymentsManager _paymentsManager;
        private readonly PaymentApi _paymentApi;

        public PaymentController(IOptions<ConnectionConfiguration> connection)
        {
            _paymentsManager = new PaymentsManager(connection.Value.ConnectionString,
                new BeneficiaryManager(connection.Value.ConnectionString)
            );

            _paymentApi = new PaymentApi(_paymentsManager);
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var paymentInfo = _paymentsManager.GetPaymentsInformation(id);

            return View(paymentInfo);
        }

        [HttpGet]
        public void DownloadPaymentPdf(int id)
        {
            _paymentsManager.DownloadPdfPayment(id);
        }

        [HttpPost]
        public void CreatePayment(int userId, int creditCardId, double value, int benId, string info)
        {
            var payment = new Payment
            {
                UserId = userId,
                CreditCardId = creditCardId,
                TransferedValue = value,
                BeneficiaryId = benId,
                Information = info
            };

            _paymentApi.CreatePayment(payment);
        }
    }
}