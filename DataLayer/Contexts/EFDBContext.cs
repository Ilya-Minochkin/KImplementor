using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionRecord> PositionRecords { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(p => p.Roles)
                .WithMany(p => p.Users)
                .UsingEntity(t => t.ToTable("RoleUser"));
        }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }
    }
}
