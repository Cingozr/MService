using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Command.Delete
{
    public class DeleteContactInformationCommand : IRequest<bool>
    {
        public Guid ContactId { get; set; }
    }
}
