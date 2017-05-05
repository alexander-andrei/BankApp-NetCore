using Microsoft.AspNetCore.Mvc;

namespace MvcApplication.Controllers
{
    public class PaymentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void DownloadPdfPayment(int paymentId)
        {
            // TODO: make logic to download payment
        }
    }
}