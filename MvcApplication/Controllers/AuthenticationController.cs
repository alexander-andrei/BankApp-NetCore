using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Services;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private const string _errorMessageKey = "_authErrorMessage";
        private readonly UserManager _userManager;

        public AuthenticationController(IOptions<ConnectionConfiguration> connection)
        {
            _userManager = new UserManager(connection.Value.ConnectionString);
        }


        public ActionResult Index()
        {
            var errorMessage = HttpContext.Session.GetString(_errorMessageKey);
            
            return View((object) errorMessage);
        }

        public ActionResult AuthenticateUser(string email, string password)
        {
            var authentication = _userManager.AuthenticateUser(email, password);

            if (authentication == false)
            {
                HttpContext.Session.SetString(_errorMessageKey, "Wrong email or password");
                return RedirectToAction("Index", "Authentication");
            }
            
            HttpContext.Session.SetInt32(AuthenticationManager.UserIdKey ,_userManager.GetUserId());
            return RedirectToAction("Index", "Home");
        }
    }
}