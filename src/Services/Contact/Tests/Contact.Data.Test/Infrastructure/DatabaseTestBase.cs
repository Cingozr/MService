using Contact.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Test.Infrastructure
{
    public class DatabaseTestBase : IDisposable
    {

        protected readonly ContactContext Context;

        public DatabaseTestBase()
        {
            var options = new DbContextOptionsBuilder<ContactContext>().UseNpgsql("Server=localhost;Port=5432;Database=cingozr_contact;User Id=postgres;Password=9511;").Options;

            Context = new ContactContext(options);

            Context.Database.EnsureCreated();   

            DatabaseInitializer.Initialize(Context);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();

            Context.Dispose();
        }
    }
}
