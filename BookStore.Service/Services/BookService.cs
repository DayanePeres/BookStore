using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Services
{
    public class BookService : BaseService<BookEntity>, IBookService
    {
        private readonly IAuthorRepository _authorRepository;
        public BookService(IBookRepository baseRepository, IAuthorRepository authorRepository ) : base(baseRepository)
        {
            _authorRepository = _authorRepository;
        }

        public override Task<BookEntity> Post(BookEntity obj)
        {

            
            obj.Id = Guid.NewGuid();
            foreach(BookAuthorEntity bookAuthor in obj.ListBookAuthor)
            {
                if (bookAuthor.AuthorId == null) {
                    continue;
                }
                bookAuthor.BookId = obj.Id;
            }

            foreach (BookGenreEntity bookGenre in obj.ListBookGenres)
            {
                if (bookGenre.GenreId == null)
                {
                    continue;
                }
                bookGenre.BookId = obj.Id;

            }

            return base.Post(obj);
        }

        
    }
}
