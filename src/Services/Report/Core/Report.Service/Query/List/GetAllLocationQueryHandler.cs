using MediatR;
using Report.Core.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Service.Query.List
{
    public class GetAllLocationQueryHandler : IRequestHandler<GetAllLocationQuery, List<string>>
    {
        private readonly IReportRepository _reportRepository;

        public GetAllLocationQueryHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<List<string>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
        {
            return await _reportRepository.GetAllLocation(cancellationToken);
        }
    }
}
