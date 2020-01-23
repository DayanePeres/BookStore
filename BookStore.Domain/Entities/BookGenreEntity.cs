using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class BookGenreEntity  
    {

        public Guid BookId { get; set; }
        public BookEntity Book { get; set; }
        public Guid GenreId { get; set; }
        public GenreEntity Genre { get; set; }


    }
}
