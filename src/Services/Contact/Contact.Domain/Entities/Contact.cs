using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.Domain.Entities
{
    public class Contact
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

    }
}
