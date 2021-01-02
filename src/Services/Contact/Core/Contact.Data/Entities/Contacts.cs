using System;
using System.Collections.Generic;

namespace Contact.Data.Entities
{
    public class Contacts
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public virtual ICollection<ContactInformations> ContactInformations { get; set; }

    }
}
