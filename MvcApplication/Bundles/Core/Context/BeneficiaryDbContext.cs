using Microsoft.EntityFrameworkCore;
using MvcApplication.Bundles.Core.Entity;

namespace MvcApplication.Bundles.Core.Context
{
    public class BeneficiaryDbContext : DbContext
    {
        private readonly string _conectionString;

        public DbSet<Beneficiary> Beneficiaries;

        public BeneficiaryDbContext(string connectionString)
        {
            _conectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(@_conectionString);
    }
}