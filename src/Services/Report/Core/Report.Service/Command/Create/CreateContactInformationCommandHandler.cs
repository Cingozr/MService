
using MediatR;
using Report.Core.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Service.Command.Create
{
    public class CreateContactInformationCommandHandler : IRequestHandler<CreateContactInformationCommand>
    {
        private readonly IReportRepository _reportRepository;

        public CreateContactInformationCommandHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Unit> Handle(CreateContactInformationCommand request, CancellationToken cancellationToken)
        {
            await _reportRepository.AddContactInformationToPerson(request.ContactInformation, cancellationToken);
            return Unit.Value;
        }
    }
}
