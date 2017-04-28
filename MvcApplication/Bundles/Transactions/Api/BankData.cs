using System;
using System.Linq;
using MvcApplication.Bundles.Core.Context;
using MvcApplication.Bundles.Core.Entity;

namespace MvcApplication.Bundles.Transactions.Api
{
    public class BankData
    {
        private readonly int _bankId;
        private readonly ActiveBankDbContext _activeBankDbContext;

        public BankData(int bankId, ActiveBankDbContext activeBankDbContext)
        {
            _bankId = bankId;
            _activeBankDbContext = activeBankDbContext;
        }

        public bool MakeTransaction()
        {
            var apiLink = GetBankInformation().ApiEntryPoint;

            return apiLink != null;
        }

        private ActiveBank GetBankInformation()
        {
            using (_activeBankDbContext)
            {
                var bank = _activeBankDbContext.ActiveBanks.Where(ab => ab.Id == _bankId).ToList();

                if (bank == null)
                {
                    throw new Exception("No bank was found");
                }

                return bank.First();
            }
        }
    }
}