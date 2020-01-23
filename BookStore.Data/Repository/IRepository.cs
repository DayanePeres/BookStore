using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Create (TEntity obj);

        Task<TEntity> Update(TEntity obj);

        Task<bool> Delete(Guid id);

        Task<TEntity> Select(Guid id);

        Task<IEnumerable<TEntity>> SelectAll();
    }
}
