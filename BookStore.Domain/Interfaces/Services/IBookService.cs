using BookStore.Domain.Entities;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces.Services
{
    public interface IBookService : IBaseService<BookEntity>
    {
    }
}
