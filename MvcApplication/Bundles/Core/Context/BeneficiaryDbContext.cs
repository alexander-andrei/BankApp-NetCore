using Microsoft.EntityFrameworkCore;
using MvcApplication.Bundles.Core.Entity;

namespace MvcApplication.Bundles.Core.Context
{
    public class BeneficiaryDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Beneficiary> Beneficiaries { get; set; }

        public BeneficiaryDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(@_connectionString);
    }
}