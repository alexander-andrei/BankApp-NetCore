using Microsoft.EntityFrameworkCore;
using MvcApplication.Bundles.CreditCardInformation.Entity;
using MvcApplication.Config.Users;

namespace MvcApplication.Bundles.CreditCardInformation.Context
{
    public class CreditCardDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<CreditCard> CreditCards { get; set; }

        public CreditCardDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(@_connectionString);
    }
}