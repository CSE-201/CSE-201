using Microsoft.EntityFrameworkCore;

namespace ScholarlySoftwareSearch.Models {
    public class ModelContext : DbContext {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options) {
        }

        public DbSet<Scholary_Software_Search.Models.Software> Software { get; set; }
    }
}
