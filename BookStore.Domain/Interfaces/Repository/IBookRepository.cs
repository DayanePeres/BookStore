using BookStore.Domain.Entities;
using System;

namespace BookStore.Domain.Interfaces.Repository
{
    public interface IBookRepository : IBaseRepository<BookEntity>
    {
        object SelectAllWithAuthorAndGenre(Guid? id);
        object SelectOneWithAuthorAndGenre(Guid id);
    }
}
