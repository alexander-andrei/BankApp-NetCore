using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Services;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager _userManager;
        private readonly AuthenticationManager _authenticationManager;
        
        public HomeController(IOptions<ConnectionConfiguration> configuration)
        {
            _userManager = new UserManager(configuration.Value.ConnectionString);
            _authenticationManager = new AuthenticationManager(_userManager);
        }

        [HttpGet]
        public ActionResult Index(int userId)
        {
            var key = HttpContext.Session.GetInt32(AuthenticationManager.UserIdKey);
            var auth = _authenticationManager.CheckIfUserIsAuthorized(key);

            if (auth == false)
            {
                return RedirectToAction("Index", "Authentication");
            }

            return View();
        }
    }
}
