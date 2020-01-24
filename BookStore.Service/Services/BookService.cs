using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Services
{
    public class BookService : BaseService<BookEntity>, IBookService
    {
        public BookService(IBaseRepository<BookEntity> baseRepository) : base(baseRepository)
        {
        }
    }
}
