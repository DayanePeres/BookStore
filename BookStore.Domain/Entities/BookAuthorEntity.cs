using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class BookAuthorEntity
    {
        public Guid BookId { get; set; }
        public BookEntity Book { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorEntity Author { get; set; }
    }
}
