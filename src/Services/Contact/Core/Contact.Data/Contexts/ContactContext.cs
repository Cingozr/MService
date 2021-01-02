using Contact.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Contact.Data.Contexts
{
    public class ContactContext : DbContext
    { 
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<ContactInformations> ContactInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
