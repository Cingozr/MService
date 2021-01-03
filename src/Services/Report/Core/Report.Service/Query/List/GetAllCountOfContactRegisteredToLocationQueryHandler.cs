using MediatR;
using Report.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Service.Query.List
{
    public class GetAllCountOfContactRegisteredToLocationQueryHandler
        : IRequestHandler<GetAllCountOfContactRegisteredToLocationQuery, int>
    {
        private readonly IReportRepository _reportRepository;

        public GetAllCountOfContactRegisteredToLocationQueryHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<int> Handle(GetAllCountOfContactRegisteredToLocationQuery request, CancellationToken cancellationToken)
        {
            return await _reportRepository.CountOfContactsRegisteredToLocation(request.Location, cancellationToken);
        }
    }
}
