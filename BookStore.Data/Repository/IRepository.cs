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
        Task Create (TEntity obj);
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
        Task<TEntity> Select(int id);
        IQueryable<TEntity> SelectAll();
    }
}
