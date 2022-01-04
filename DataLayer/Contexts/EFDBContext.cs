using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }
    }
}
