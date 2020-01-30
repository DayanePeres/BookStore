using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;

namespace BookStore.Application.Controllers
{
    public class GenreController : BaseController<GenreEntity>
    {
        public GenreController(IGenreService genreService) : base(genreService)
        {

        }
    }
}
