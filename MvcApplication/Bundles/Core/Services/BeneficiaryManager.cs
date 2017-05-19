using System;
using System.Collections.Generic;
using System.Linq;
using MvcApplication.Bundles.Core.Context;
using MvcApplication.Bundles.Core.Entity;
using MvcApplication.Bundles.Core.Services.Manager;

namespace MvcApplication.Bundles.Core.Services
{
    public class BeneficiaryManager : BaseManager<Beneficiary>
    {
        public BeneficiaryManager(string connectionString) : base(connectionString)
        {
        }

        public override List<Beneficiary> GetAll(int id = 0)
        {
            List<Beneficiary> beneficiaries;
            using (var benCtx = new BeneficiaryDbContext(GetConnectionString()))
            {
                beneficiaries = (id != 0) ? benCtx.Beneficiaries.Where(ben => ben.Id == id).ToList() : benCtx.Beneficiaries.ToList();
            }

            return beneficiaries;
        }

        public void SaveBeneficiary(Beneficiary beneficiary)
        {
            try
            {
                using (var benCtx = new BeneficiaryDbContext(GetConnectionString()))
                {
                    benCtx.Beneficiaries.Add(beneficiary);
                    benCtx.SaveChanges();
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