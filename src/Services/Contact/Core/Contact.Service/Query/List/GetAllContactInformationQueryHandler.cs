using Contact.Core.Repository;
using Contact.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Service.Query.List
{
    public class GetAllContactInformationQueryHandler : IRequestHandler<GetAllContactInformationQuery, List<Contacts>>
    {
        private readonly IContactRepository _contactRepository;

        public GetAllContactInformationQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<List<Contacts>> Handle(GetAllContactInformationQuery request, CancellationToken cancellationToken)
        {
            return await _contactRepository.GetAllContactInformation(cancellationToken);
        }
    }
}
