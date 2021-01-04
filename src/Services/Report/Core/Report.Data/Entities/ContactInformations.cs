using System;

namespace Report.Data.Entities
{
    public class ContactInformations
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Detail { get; set; }
        public InfoType InfoType { get; set; }
    }

    public enum InfoType
    {
        Phone = 0,
        Email,
        Location
    }
}
