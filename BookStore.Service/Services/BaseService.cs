using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
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

        public void Delete(Guid id)
        {
            baseRepository.Delete(id);
        }

        public async Task<bsEntity> Get(Guid id)
        {
            return await baseRepository.Select(id);
        }

        public async Task<IEnumerable<bsEntity>> Get()
        {
            return await baseRepository.SelectAll();
        }

        public async Task<bsEntity> Post<AbsValid>(bsEntity obj) where AbsValid : AbstractValidator<bsEntity>
        {
            return await baseRepository.Create(obj);

        }

        public async Task<bsEntity> Put<AbsValid>(bsEntity obj) where AbsValid : AbstractValidator<bsEntity>
        {
            return await baseRepository.Update(obj);
        }
    }
}
