using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Services;
using MvcApplication.Bundles.Payments.Context;
using MvcApplication.Bundles.Payments.Dto;
using MvcApplication.Bundles.Payments.Entity;
using MvcApplication.Bundles.Payments.Services;
using MvcApplication.Config.Connection;

namespace MvcApplication.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PaymentsManager _paymentsManager;
        private readonly BeneficiaryManager _beneficiaryManager;

        public PaymentController(IOptions<ConnectionConfiguration> connection)
        {
            _paymentsManager = new PaymentsManager(connection.Value.ConnectionString);
            _beneficiaryManager = new BeneficiaryManager(connection.Value.ConnectionString);
        }

        public ActionResult Index(int id)
        {
            var payments = _paymentsManager.GetAll(id);
            var paymentDtos = new List<PaymentDto>();

            foreach (var payment in payments)
            {
                try
                {
                    var ben = _beneficiaryManager.GetAll(payment.BeneficiaryId).First();

                    var paymentDto = new PaymentDto()
                    {
                        Id = payment.Id,
                        Beneficiary = ben,
                        TransferedValue = payment.TransferedValue
                    };

                    paymentDtos.Add(paymentDto);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }

            return View(paymentDtos);
        }
    }
}