using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ClinicDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);
        }

        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
