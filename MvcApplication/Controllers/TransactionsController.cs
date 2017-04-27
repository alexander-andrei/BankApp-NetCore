using Microsoft.AspNetCore.Mvc;

namespace MvcApplication.Controllers
{
    public class TransactionsController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}