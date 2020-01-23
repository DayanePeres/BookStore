using BookStore.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Repository
{
    public interface IService <bsEntity> where bsEntity : BaseEntity
    {
        bsEntity Post<AbsValid>(bsEntity obj) where AbsValid : AbstractValidator<bsEntity>;
        bsEntity Put<AbsValid>(bsEntity obj) where AbsValid : AbstractValidator<bsEntity>;
        void Delete(int id);
        bsEntity Get(int id);
        IList<bsEntity> Get();

    }
}
