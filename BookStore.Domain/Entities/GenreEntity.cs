using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class GenreEntity : BaseEntity
    {
        public string Name { get; set; }
        public IList<BookGenreEntity> ListBookGenres { get; set; }
    }
}
