using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connectionString;

        public HomeController(IOptions<ConnectionConfiguration> configuration)
        {
            _connectionString = configuration.Value.ConnectionString;
        }

        public ActionResult Index(int userId)
        {
            return View();
        }
    }
}
