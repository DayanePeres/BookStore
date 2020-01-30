using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Repository
{
    public interface IBookRepository : IBaseRepository<BookEntity>
    {
    }
}
