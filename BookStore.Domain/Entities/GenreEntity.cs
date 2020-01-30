using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class GenreEntity : BaseEntity
    {
        public string Name { get; set; }
        public IList<BookGenreEntity> ListBookGenres { get; set; }
    }
}
