using Report.Data.Contexts;
using System;
using System.Threading.Tasks;

namespace Report.Core.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly ReportContext ReportContext;

        public Repository(ReportContext reportContext)
        {
            ReportContext = reportContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                await ReportContext.AddAsync(entity);
                await ReportContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                ReportContext.Update(entity);
                await ReportContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
            }
        }
    }
}
