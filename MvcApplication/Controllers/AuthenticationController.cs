using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Services;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserManager _userManager;

        public AuthenticationController(IOptions<ConnectionConfiguration> connection)
        {
            _userManager = new UserManager(connection.Value.ConnectionString);
        }


        public ActionResult Index()
        {
            return View();
        }

        public void AuthenticateUser(string email, string password)
        {
            var authentication = _userManager.AuthenticateUser(email, password);

            if (authentication == false)
            {
                // TODO: Show failed to authenticate message
            }
            // TODO: if not false reddirect to succes
        }
    }
}