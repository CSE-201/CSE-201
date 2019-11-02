using Microsoft.EntityFrameworkCore;

namespace ScholarlySoftwareSearch.Models {
    public class ModelContext : DbContext {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options) {
        }
        public DbSet<ScholarlySoftwareSearch.Models.Software> Software { get; set; }
        public DbSet<ScholarlySoftwareSearch.Models.ClippedSoftware> ClippedSoftware { get; set; }
    }
}
