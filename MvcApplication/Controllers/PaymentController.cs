using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcApplication.Bundles.Payments.Context;
using MvcApplication.Bundles.Payments.Entity;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class PaymentController : Controller
    {
        private string _connectionString;

        public PaymentController(ConnectionConfiguration connection)
        {
            _connectionString = connection.ConnectionString;
        }

        public ActionResult Index()
        {
            return View();
        }

        public void DownloadPdfPayment(int paymentId)
        {
            Payment payment = null;
            using (var paymentCtx = new PaymentDbContext(_connectionString))
            {
                payment = paymentCtx.Payments.Where(p => p.Id == paymentId).ToList().First();
            }

            if (payment == null)
            {
                throw new Exception("No payment was found");
            }

            // TODO: make logic to download payment
        }
    }
}