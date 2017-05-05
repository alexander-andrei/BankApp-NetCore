using Microsoft.EntityFrameworkCore;
using MvcApplication.Bundles.Payments.Entity;

namespace MvcApplication.Bundles.Payments.Context
{
    public class PaymentDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Payment> Payments { get; set; }

        public PaymentDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(@_connectionString);
    }
}