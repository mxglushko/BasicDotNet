using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public sealed class BasicDotNetDataContext : DbContext
    {
        public DbSet<SchoolchildrenDB> Schoolchildren { get; set; }
        public DbSet<ElectiveDB> Electives { get; set; }
        public DbSet<SchoolchildrenElectivesDB> SchoolchildrenElectives { get; set; }

        public BasicDotNetDataContext(DbContextOptions<BasicDotNetDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SchoolchildrenDB>().HasMany(s => s.SchoolchildrenElectives).WithOne(s => s.Schoolchildren).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ElectiveDB>().HasMany(s => s.SchoolchildrenElectives).WithOne(s => s.Elective).OnDelete(DeleteBehavior.Cascade);
        }
    }
}