using System;

namespace Contact.Data.Entities
{
    public class ContactInformations
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Detail { get; set; }
        public Guid ContactId { get; set; }
        public virtual Contacts Contact { get; set; }
    }

    public enum InfoType
    {
        Phone = 0,
        Email,
        Location
    }
}
