using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IBaseService<bsEntity> where bsEntity : BaseEntity
    {
        Task<bsEntity> Post(bsEntity obj);
        Task<bsEntity> Put(bsEntity obj);
        Task<bool> Delete(Guid id);
        Task<bsEntity> Get(Guid id);
        Task<IEnumerable<bsEntity>> Get();

    }
}
