using Microsoft.EntityFrameworkCore;

namespace StoreAnything.Models {
    public class ApplicationContext : DbContext {
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base (options) { }

        public DbSet<Item> Items { get; set; }
    }
}