using Microsoft.AspNetCore.Mvc;

namespace MvcApplication.Controllers
{
    public class PaymentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}