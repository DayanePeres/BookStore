using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Create(TEntity obj);

        Task<TEntity> Update(TEntity obj);

        Task<bool> Delete(Guid id);

        Task<TEntity> Select(Guid id);

        Task<IEnumerable<TEntity>> SelectAll();
    }
}
