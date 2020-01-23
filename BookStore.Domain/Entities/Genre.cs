using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public IList<BookGenre> bookGenres { get; set; }
    }
}
