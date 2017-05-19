using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Services;
using MvcApplication.Bundles.Payments.Services;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PaymentsManager _paymentsManager;

        public PaymentController(IOptions<ConnectionConfiguration> connection)
        {
            _paymentsManager = new PaymentsManager(connection.Value.ConnectionString,
                new BeneficiaryManager(connection.Value.ConnectionString)
            );
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var paymentInfo = _paymentsManager.GetPaymentsInformation(id);

            return View(paymentInfo);
        }

        public void DownloadPaymentPdf(int id)
        {
            _paymentsManager.DownloadPdfPayment(id);
        }
    }
}