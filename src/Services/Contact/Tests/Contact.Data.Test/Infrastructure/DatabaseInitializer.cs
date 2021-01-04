using Contact.Data.Contexts;
using Contact.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact.Data.Test.Infrastructure
{
    public class DatabaseInitializer
    {
        public static void Initialize(ContactContext context)
        {
            if (context.Contacts.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(ContactContext context)
        {
            var customers = new[]
            {
                new Contacts
                {
                    UUID = Guid.Parse("9f35b48d-cb87-4783-bfdb-21e36012930a"),
                    Name="Recai",
                    Surname="Cingoz",
                    Company="Rega",
                }
            };

            context.Contacts.AddRange(customers);
            context.SaveChanges();
        }
    }
}
