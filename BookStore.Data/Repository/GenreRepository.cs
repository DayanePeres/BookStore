using BookStore.Data.Context;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repository
{
    public class GenreRepository : BaseRepository<GenreEntity>, IGenreRepository
    {
        public GenreRepository(MyContext context) : base(context)
        {

        }
    }
}
