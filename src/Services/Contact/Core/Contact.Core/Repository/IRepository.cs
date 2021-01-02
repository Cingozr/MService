using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
