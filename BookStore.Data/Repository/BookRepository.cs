using BookStore.Data.Context;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repository
{
    public class BookRepository : BaseRepository<BookEntity>, IBookRepository
    {
        public BookRepository(MyContext context) : base(context)
        {

        }

         
    }
}
