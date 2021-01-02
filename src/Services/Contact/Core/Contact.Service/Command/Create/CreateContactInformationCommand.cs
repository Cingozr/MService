using Contact.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Command.Create
{
    public class CreateContactInformationCommand : IRequest<bool>
    {
        public ContactInformations ContactInformation { get; set; }
    }
}
