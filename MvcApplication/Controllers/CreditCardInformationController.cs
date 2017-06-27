using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Services;
using MvcApplication.Bundles.CreditCardInformation.Services;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class CreditCardInformationController : Controller
    {
        private readonly CreditCardManager _creditCardManager;
        private readonly UserManager _userManager;
        private readonly AuthenticationManager _authenticationManager;

        public CreditCardInformationController(IOptions<ConnectionConfiguration> configuration)
        {
            _creditCardManager = new CreditCardManager(configuration.Value.ConnectionString);
            _userManager = new UserManager(configuration.Value.ConnectionString);
            _authenticationManager = new AuthenticationManager(_userManager);
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var key = HttpContext.Session.GetInt32(AuthenticationManager.UserIdKey);
            var auth = _authenticationManager.CheckIfUserIsAuthorized(key);

            if (auth == false)
            {
                return RedirectToAction("Index", "Authentication");
            }
            
            var creditCards = _creditCardManager.GetAll(id);

            return View(creditCards);
        }

        [HttpPut]
        public void ChangePinNumber(int creditCardId, string pinNumber)
        {
            _creditCardManager.ChangeCardPin(creditCardId, pinNumber);
        }

        [HttpPut]
        public void Manage3DSecure(int creditCardId, bool status)
        {
            _creditCardManager.Change3DSecureStatus(creditCardId, status);
        }
    }
}