using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Models
{
    public class GetAllContactInformation
    {
        public GetAllContactInformation()
        {
            ContactInformations = new List<ContactInformationModel>();
        }
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<ContactInformationModel> ContactInformations { get; set; }
    }


}
