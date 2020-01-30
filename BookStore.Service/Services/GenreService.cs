using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Interfaces.Services;

namespace BookStore.Service.Services
{
    public class GenreService : BaseService<GenreEntity>, IGenreService
    {
        public GenreService(IBaseRepository<GenreEntity> baseRepository) : base(baseRepository)
        {
        }
    }
}
