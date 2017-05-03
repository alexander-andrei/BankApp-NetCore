using Microsoft.EntityFrameworkCore;
using MvcApplication.Bundles.Transactions.Entity;

namespace MvcApplication.Bundles.Transactions.Context
{
    public class TransactionDbContext : DbContext
    {
        private readonly  string _connectionString;

        public DbSet<Transaction> Transactions { get; set; }

        public TransactionDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(@_connectionString);
    }
}