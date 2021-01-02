using Contact.Core.Repository;
using Contact.Service.Command.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Service.Command.Delete
{
    public class DeleteContactInformationCommandHandler : IRequestHandler<DeleteContactInformationCommand, bool>
    {
        private readonly IContactRepository _contactRepository;
        public DeleteContactInformationCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> Handle(DeleteContactInformationCommand request, CancellationToken cancellationToken)
        {
            return await _contactRepository.RemoveContactInformationToPerson(request.ContactId, cancellationToken);
        }
    }
}
