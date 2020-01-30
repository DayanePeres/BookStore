using BookStore.Domain.Entities;
using System;

namespace BookStore.Domain.Interfaces.Services
{
    public interface IBookService : IBaseService<BookEntity>
    {
        object GetAllWithAuthorAndGenre();
        object GetOneWithAuthorAndGenre(Guid id);
    }
}
