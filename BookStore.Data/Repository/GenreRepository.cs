using BookStore.Data.Context;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;

namespace BookStore.Data.Repository
{
    public class GenreRepository : BaseRepository<GenreEntity>, IGenreRepository
    {
        public GenreRepository(MyContext context) : base(context)
        {

        }
    }
}
