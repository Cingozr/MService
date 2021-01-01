using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.Domain.Entities
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public string InfoDetail { get; set; }
        public InfoType InfoType { get; set; }
    }

    public enum InfoType
    {
        Phone = 0,
        Email,
        Location
    }
}
