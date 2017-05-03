using Microsoft.EntityFrameworkCore;
using MvcApplication.Bundles.Core.Entity;

namespace MvcApplication.Bundles.Core.Context
{
    public class UserDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<User> Users { get; set; }

        public UserDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(@_connectionString);
    }
}