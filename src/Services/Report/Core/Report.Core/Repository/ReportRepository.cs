using Microsoft.EntityFrameworkCore;
using Report.Data.Contexts;
using Report.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Core.Repository
{
    public class ReportRepository : Repository<Reports>, IReportRepository
    {
        public ReportRepository(ReportContext reportContext) : base(reportContext) { }

        public async Task<bool> AddContactInformationToPerson(ContactInformations model, CancellationToken cancellationToken)
        {
            if (model == null)
                throw new ArgumentNullException($"{nameof(AddContactInformationToPerson)} entity must not be null");

            try
            {
                await ReportContext.ContactInformations.AddAsync(model, cancellationToken);
                return await ReportContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(model)} could not be saved: {ex.Message}");
            }

        }

        public async Task<int> CountOfContactsRegisteredToLocation(string location, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(location))
                throw new ArgumentNullException($"{nameof(CountOfContactsRegisteredToLocation)} location must not be null");

            try
            {
                return await ReportContext.ContactInformations
                    .Where(x => x.InfoType == InfoType.Location && x.Info == location)
                    .CountAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(CountOfContactsRegisteredToLocation)} : {ex.Message}");
            }
        }

        public async Task<List<string>> GetAllLocation(CancellationToken cancellationToken)
        {
            try
            {
                return await ReportContext.ContactInformations
                    .Where(x => x.InfoType == InfoType.Location)
                    .Select(x => x.Info)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetAllLocation)} : {ex.Message}");
            }
        }

        public async Task<int> NumbersInLocation(string location, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(location))
                throw new ArgumentNullException($"{nameof(NumbersInLocation)} location must not be null");

            try
            {
                return await ReportContext.ContactInformations
                    .Where(x => x.InfoType == InfoType.Phone)
                    .CountAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(NumbersInLocation)} : {ex.Message}");
            }
        }
    }
}
