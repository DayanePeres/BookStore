using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class BookGenreEntity  
    {

        public Guid BookId { get; set; }
        public virtual BookEntity Book { get; set; }
        public Guid GenreId { get; set; }
        public virtual GenreEntity Genre { get; set; }


    }
}
