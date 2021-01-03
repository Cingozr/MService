using Contact.Core.Repository;
using Contact.Messaging.Sender; 
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
        private readonly IContactInformationSender _contactInformationSender;

        public CreateContactInformationCommandHandler(
            IContactRepository contactRepository,
            IContactInformationSender contactInformationSender)
        {
            _contactRepository = contactRepository;
            _contactInformationSender = contactInformationSender;
        }

        public async Task<bool> Handle(CreateContactInformationCommand request, CancellationToken cancellationToken)
        {
            if (await _contactRepository.AddContactInformationToPerson(request.ContactInformation, cancellationToken))
            {
                _contactInformationSender.AddContactInformationToPerson(request.ContactInformation);
                return true;
            }

            return false;
        }
    }
}
