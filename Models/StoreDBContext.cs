using Microsoft.EntityFrameworkCore;

namespace Entertainment_Guild.Models
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Stocktake> Stocktake { get; set; }
        public DbSet<User> User { get; set; }
    }
}
