using Microsoft.AspNetCore.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int userId)
        {
            return View();
        }
    }
}
