using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Core.Repository
{
    public interface IReportRepository
    {
        Task<List<string>> GetAllLocation(CancellationToken cancellationToken);
        Task<int> CountOfContactsRegisteredToLocation(string location, CancellationToken cancellationToken);
        Task<int> NumbersInLocation(string location, CancellationToken cancellationToken);
    }
}
