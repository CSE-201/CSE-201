using Microsoft.EntityFrameworkCore;

namespace ScholarlySoftwareSearch.Models {
    public class SoftwareContext : DbContext {
        public SoftwareContext(DbContextOptions<SoftwareContext> options)
            : base(options) {
        }

        public DbSet<Scholary_Software_Search.Models.Software> Software { get; set; }
    }
}
