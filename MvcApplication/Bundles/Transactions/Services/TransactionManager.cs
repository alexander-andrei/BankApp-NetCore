using System;
using System.Collections.Generic;
using System.Linq;
using MvcApplication.Bundles.Core.Services.Manager;
using MvcApplication.Bundles.Transactions.Context;
using MvcApplication.Bundles.Transactions.Entity;

namespace MvcApplication.Bundles.Transactions.Services
{
    public class TransactionManager : BaseManager<Transaction>
    {
        public TransactionManager(string connectionString) : base(connectionString)
        {
        }

        public override List<Transaction> GetAll(int id = 0)
        {
            List<Transaction> transactions;
            try
            {
                using (var transactionCtx = new TransactionDbContext(GetConnectionString()))
                {
                    transactions = transactionCtx.Transactions.Where(t => t.Id == id).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return transactions;
        }

        public void SaveTransaction(Transaction transaction)
        {
            try
            {
                using (var transactionCtx = new TransactionDbContext(GetConnectionString()))
                {
                    transactionCtx.Transactions.Add(transaction);
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