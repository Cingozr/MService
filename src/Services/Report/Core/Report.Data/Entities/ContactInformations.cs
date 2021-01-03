using System;

namespace Report.Data.Entities
{
    public class ContactInformations
    {
        public int Id { get; set; }
        public int ContactInformationPK { get; set; }
        public string Info { get; set; }
        public InfoType InfoType { get; set; }
    }

    public enum InfoType
    {
        Phone = 0,
        Email,
        Location
    }
}
