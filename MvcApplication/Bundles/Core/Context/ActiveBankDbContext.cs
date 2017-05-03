using Microsoft.EntityFrameworkCore;
using MvcApplication.Bundles.Core.Entity;

namespace MvcApplication.Bundles.Core.Context
{
    public class ActiveBankDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<ActiveBank> ActiveBanks { get; set; }

        public ActiveBankDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(@_connectionString);
    }
}