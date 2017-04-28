using Microsoft.EntityFrameworkCore;
using MvcApplication.Bundles.Core.Entity;

namespace MvcApplication.Bundles.Core.Context
{
    public class ActiveBankDbContext : DbContext
    {
        private readonly string _conectionString;

        public DbSet<ActiveBank> ActiveBanks;

        public ActiveBankDbContext(string conectionString)
        {
            _conectionString = conectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(@_conectionString);
    }
}