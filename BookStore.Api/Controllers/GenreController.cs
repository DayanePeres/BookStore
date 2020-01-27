using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.Controllers
{
    public class GenreController : BaseController<GenreEntity>
    {
        public GenreController(IGenreService genreService) : base(genreService)
        {

        }
    }
}
