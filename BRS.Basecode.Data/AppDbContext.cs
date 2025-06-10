using BRS.Basecode.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BRS.Basecode.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
