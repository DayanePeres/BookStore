using BookStore.Data.Context;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;

namespace BookStore.Data.Repository
{
    public class AuthorRepository : BaseRepository<AuthorEntity> , IAuthorRepository
    {
        public AuthorRepository(MyContext context) : base(context)
        {

        }
    }
}
