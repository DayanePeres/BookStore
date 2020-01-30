using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Service.Services
{
    public class BaseService<bsEntity> : IBaseService<bsEntity> where bsEntity : BaseEntity
    {
        private readonly IBaseRepository<bsEntity> baseRepository;

        public BaseService(IBaseRepository<bsEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await baseRepository.Delete(id);
        }

        public async Task<bsEntity> Get(Guid id)
        {
            return await baseRepository.Select(id);
        }

        public async Task<IEnumerable<bsEntity>> Get()
        {
            return await baseRepository.SelectAll();
        }

        public virtual async Task<bsEntity> Post(bsEntity obj)
        {
            return await baseRepository.Create(obj);

        }

        public async Task<bsEntity> Put (bsEntity obj)
        {
            return await baseRepository.Update(obj);
        }
    }
}
