using Contact.Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Service.Command.Create
{
    public class CreateContactInformationCommandHandler : IRequestHandler<CreateContactInformationCommand, bool>
    {
        private readonly IContactRepository _contactRepository;

        public CreateContactInformationCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> Handle(CreateContactInformationCommand request, CancellationToken cancellationToken)
        {
            return await _contactRepository.AddContactInformationToPerson(request.ContactInformation, cancellationToken);
        }
    }
}
