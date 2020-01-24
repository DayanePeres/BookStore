using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Services
{
    public interface IAuthorService : IBaseService<AuthorEntity>
    {

    }
}
