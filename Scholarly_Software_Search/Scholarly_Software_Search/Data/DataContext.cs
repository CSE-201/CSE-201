using Microsoft.EntityFrameworkCore;

namespace Scholary_Software_Search.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) {
        }

        public DbSet<Scholary_Software_Search.Models.Software> Software { get; set; }

    }
}
