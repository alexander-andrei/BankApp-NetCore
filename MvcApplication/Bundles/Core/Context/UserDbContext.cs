using Microsoft.EntityFrameworkCore;
using MvcApplication.Bundles.Core.Entity;

namespace MvcApplication.Bundles.Core.Context
{
    public class UserDbContext : DbContext
    {
        private readonly string _conectionString;

        public DbSet<User> Users { get; set; }

        public UserDbContext(string conectionString)
        {
            _conectionString = conectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(@_conectionString);
    }
}