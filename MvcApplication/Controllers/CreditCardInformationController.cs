using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.CreditCardInformation.Services;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class CreditCardInformationController : Controller
    {
        private readonly string _connectionString;

        private readonly CreditCardManager _creditCardManager;

        public CreditCardInformationController(IOptions<ConnectionConfiguration> configuration)
        {
            _connectionString = configuration.Value.ConnectionString;

            _creditCardManager = new CreditCardManager(configuration.Value.ConnectionString);
        }

        public ViewResult Index(int id)
        {
            var creditCards = _creditCardManager.GetUserCreditCards(id);

            return View(creditCards);
        }

        public void ChangePinNumber(int creditCardId, string pinNumber)
        {
            _creditCardManager.ChangeCardPin(creditCardId, pinNumber);
        }

        public void Manage3DSecure(int creditCardId, bool status)
        {
            _creditCardManager.Change3dSecureStatus(creditCardId, status);
        }
    }
}