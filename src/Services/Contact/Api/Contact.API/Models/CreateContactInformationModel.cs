using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Models
{
    public class CreateContactInformationModel
    {
        public string Info { get; set; }
        public InfoTypeEnumModel InfoType { get; set; }
        public string InfoDetail { get; set; }
        public Guid ContactId { get; set; }
    }
}
