using System.Threading.Tasks;

namespace Report.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
