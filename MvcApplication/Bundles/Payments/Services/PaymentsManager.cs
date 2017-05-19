using System;
using System.Collections.Generic;
using System.Linq;
using MvcApplication.Bundles.Core.Entity;
using MvcApplication.Bundles.Core.Services;
using MvcApplication.Bundles.Core.Services.Manager;
using MvcApplication.Bundles.Payments.Context;
using MvcApplication.Bundles.Payments.Dto;
using MvcApplication.Bundles.Payments.Entity;

namespace MvcApplication.Bundles.Payments.Services
{
    public class PaymentsManager : BaseManager<Payment>
    {
        private readonly BeneficiaryManager _beneficiaryManager;

        public PaymentsManager(string connectionString, BeneficiaryManager beneficiaryManager) : base(connectionString)
        {
            _beneficiaryManager = beneficiaryManager;
        }

        public override List<Payment> GetAll(int id = 0)
        {
            List<Payment> payments;

            try
            {
                using (var paymentCtx = new PaymentDbContext(GetConnectionString()))
                {
                    payments = paymentCtx.Payments.Where(p => p.UserId == id).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return payments;
        }

        public List<PaymentDto> GetPaymentsInformation(int id)
        {
            var payments = GetAll(id);
            var paymentDtos = new List<PaymentDto>();

            foreach (var payment in payments)
            {
                try
                {
                    var ben = _beneficiaryManager.GetAll(payment.BeneficiaryId).First();
                    var paymentDto = MergeBeneficiaryAndPayments(payment, ben);

                    paymentDtos.Add(paymentDto);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return paymentDtos;
        }

        public void DownloadPdfPayment(int paymentId)
        {
            Payment payment;
            using (var paymentCtx = new PaymentDbContext("test"))
            {
                payment = paymentCtx.Payments.Where(p => p.Id == paymentId).ToList().First();
            }

            if (payment == null)
            {
                throw new Exception("No payment was found");
            }

            // TODO: make logic to download payment
        }

        private PaymentDto MergeBeneficiaryAndPayments(Payment payment, Beneficiary ben)
        {
            var paymentDto = new PaymentDto()
            {
                Id = payment.Id,
                Beneficiary = ben,
                TransferedValue = payment.TransferedValue
            };

            return paymentDto;
        }

        public void CreatePayment(Payment payment)
        {
            try
            {
                using (var transactionCtx = new PaymentDbContext(GetConnectionString()))
                {
                    transactionCtx.Payments.Add(payment);
                    transactionCtx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}