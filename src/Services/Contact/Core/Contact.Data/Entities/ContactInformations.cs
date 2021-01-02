using System;

namespace Contact.Data.Entities
{
    public class ContactInformations
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public InfoType InfoType { get; set; }
        public string InfoDetail { get; set; }
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
