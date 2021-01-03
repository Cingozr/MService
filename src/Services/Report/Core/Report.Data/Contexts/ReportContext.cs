using Microsoft.EntityFrameworkCore;
using Report.Data.Entities;
using System.Reflection;

namespace Report.Data.Contexts
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options) : base(options) { }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<ContactInformations> ContactInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
