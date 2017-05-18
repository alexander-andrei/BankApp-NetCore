using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.CreditCardInformation.Services;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class CreditCardInformationController : Controller
    {
        private readonly CreditCardManager _creditCardManager;

        public CreditCardInformationController(IOptions<ConnectionConfiguration> configuration)
        {
            _creditCardManager = new CreditCardManager(configuration.Value.ConnectionString);
        }

        [HttpGet]
        public ViewResult Index(int id)
        {
            var creditCards = _creditCardManager.GetUserCreditCards(id);

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
            _creditCardManager.Change3dSecureStatus(creditCardId, status);
        }
    }
}