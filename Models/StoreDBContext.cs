using Microsoft.EntityFrameworkCore;

namespace Entertainment_Guild.Models
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
    }
}
