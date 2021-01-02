using Contact.Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Service.Command.Delete
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, bool>
    {
        private readonly IContactRepository _contactRepository;
        public DeleteContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            return await _contactRepository.RemoveContact(request.ContactId, cancellationToken);
        }
    }
}
