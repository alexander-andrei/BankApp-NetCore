using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Services;
using MvcApplication.Bundles.Payments.Api;
using MvcApplication.Bundles.Payments.Entity;
using MvcApplication.Bundles.Payments.Services;
using MvcApplication.Config.Connection;
using MvcApplication.Bundles.Core.Api.Response;
using Microsoft.AspNetCore.Http;


namespace MvcApplication.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PaymentsManager _paymentsManager;
        private readonly PaymentApi _paymentApi;
        private readonly UserManager _userManager;
        private readonly AuthenticationManager _authenticationManager;

        public PaymentController(IOptions<ConnectionConfiguration> connection)
        {
            _paymentsManager = new PaymentsManager(connection.Value.ConnectionString,
                new BeneficiaryManager(connection.Value.ConnectionString)
            );

            _paymentApi = new PaymentApi(_paymentsManager, new Bundles.Core.Api.Response.StatusCodes());
            _userManager = new UserManager(connection.Value.ConnectionString);
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
            
            var paymentInfo = _paymentsManager.GetPaymentsInformation(id);

            return View(paymentInfo);
        }

        [HttpGet]
        public void DownloadPaymentPdf(int id)
        {
            _paymentsManager.DownloadPdfPayment(id);
        }

        [HttpPost]
        public void CreatePayment(int userId, int creditCardId, double value, int benId, string info)
        {
            var payment = new Payment
            {
                UserId = userId,
                CreditCardId = creditCardId,
                TransferedValue = value,
                BeneficiaryId = benId,
                Information = info
            };

            _paymentApi.CreatePayment(payment);
        }
    }
}