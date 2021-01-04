using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Models
{
    public class CreateContactInformationModel
    {
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Detail { get; set; }
        public InfoTypeEnumModel InfoType { get; set; }
        public Guid ContactId { get; set; }
    }
}
