using Contact.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Query.List
{
    public class GetAllContactInformationQuery : IRequest<List<Contacts>>
    {
        public List<Contacts> GetAllContactInformation { get; set; }
    }
}
