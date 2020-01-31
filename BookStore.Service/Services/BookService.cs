using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace BookStore.Service.Services
{
    public class BookService : BaseService<BookEntity>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository baseRepository) : base(baseRepository)
        {
            _bookRepository = baseRepository;
        }

        public override Task<BookEntity> Post(BookEntity obj)
        {

            
            obj.Id = Guid.NewGuid();
            foreach(BookAuthorEntity bookAuthor in obj.ListBookAuthor)
            {
                bookAuthor.BookId = obj.Id;
            }

            foreach (BookGenreEntity bookGenre in obj.ListBookGenres)
            {
                bookGenre.BookId = obj.Id;

            }
            return base.Post(obj);
        }

        public object GetAllWithAuthorAndGenre() {
            return _bookRepository.SelectAllWithAuthorAndGenre(null);
        }

        public object GetOneWithAuthorAndGenre(Guid id)
        {
            return _bookRepository.SelectOneWithAuthorAndGenre(id);
        }

    }
}
