using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Interfaces.Repository
{
    public interface IBookRepository : IBaseRepository<BookEntity>
    {
    }
}
