using Microsoft.EntityFrameworkCore;

namespace DigitalDetoxSystem.Models
{
    public class DigitalDetoxDBContext : DbContext
    {
        public DigitalDetoxDBContext(DbContextOptions<DigitalDetoxDBContext> options)
            : base(options)
        {
        }

        public DbSet<UsageLog> UsageLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsageLog>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Reason).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Timestamp).IsRequired();
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);

            });
        }
    }
}
