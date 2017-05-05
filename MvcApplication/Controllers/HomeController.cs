using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcApplication.Bundles.CreditCardInformation.Context;
using MvcApplication.Bundles.CreditCardInformation.Entity;
using MvcApplication.Config.Users;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connectionString;

        public HomeController(ConnectionConfiguration configuration)
        {
            _connectionString = configuration.ConnectionString;
        }

        public ViewResult Index(int userId)
        {
            List<CreditCard> creditCards = null;
            using (var ccCtx = new CreditCardDbContext(_connectionString))
            {
                creditCards = ccCtx.CreditCards.Where(cc => cc.UserId == userId).ToList();
            }

            return (creditCards == null) ? null : View(creditCards);
        }
    }
}
