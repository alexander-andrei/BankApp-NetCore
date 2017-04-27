using Microsoft.EntityFrameworkCore;
using MvcApplication.Bundles.Core.Entity;

namespace MvcApplication.Bundles.Core.Context
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(@"Server=localhost;database=banking;uid=root;pwd=root;");
    }
}