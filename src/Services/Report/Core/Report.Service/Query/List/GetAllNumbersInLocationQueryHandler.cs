using MediatR;
using Report.Core.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Service.Query.List
{
    public class GetAllNumbersInLocationQueryHandler : IRequestHandler<GetAllNumbersInLocationQuery, int>
    {
        private readonly IReportRepository _reportRepository;

        public GetAllNumbersInLocationQueryHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<int> Handle(GetAllNumbersInLocationQuery request, CancellationToken cancellationToken)
        {
            return await _reportRepository.NumbersInLocation(request.Location, cancellationToken);
        }
    }
}
