using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class BookEntity : BaseEntity
    {
        public string Name{ get; set; }
        public decimal Price{ get; set; }
        public int Quantity { get; set; }

        public IList<BookAuthorEntity> ListBookAuthor { get; set; }
        public IList<BookGenreEntity> ListBookGenres { get; set; }

    }
}
