using BookStore.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IBaseService<bsEntity> where bsEntity : BaseEntity
    {
        Task<bsEntity> Post<AbsValid>(bsEntity obj) where AbsValid : AbstractValidator<bsEntity>;
        Task<bsEntity> Put<AbsValid>(bsEntity obj) where AbsValid : AbstractValidator<bsEntity>;
        void Delete(Guid id);
        Task<bsEntity> Get(Guid id);
        Task<IEnumerable<bsEntity>> Get();

    }
}
