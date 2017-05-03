using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Caching.Memory;
using MvcApplication.Bundles.Core.Context;
using MvcApplication.Bundles.Core.Entity;

namespace MvcApplication.Bundles.Transactions.Api
{
    public class BankApi
    {
        private readonly int _bankId;
        private readonly ActiveBankDbContext _activeBankDbContext;
        private readonly Beneficiary _beneficiary;

        public BankApi(int bankId, ActiveBankDbContext activeBankDbContext, Beneficiary beneficiary)
        {
            _bankId = bankId;
            _activeBankDbContext = activeBankDbContext;
            _beneficiary = beneficiary;
        }

        public bool MakeTransaction()
        {
            // Use beneficiary to make the transaction
            // POST to api url using beneficiary
            var apiUrl = GetBankInformation().ApiEntryPoint;

            return true;
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