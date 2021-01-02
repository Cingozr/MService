using Contact.Data.Entities;
using MediatR;

namespace Contact.Service.Command.Create
{
    public class CreateContactCommand : IRequest<bool>
    {
        public Contacts Contact { get; set; }
    }
}
