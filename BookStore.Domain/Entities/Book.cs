using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name{ get; set; }
        public decimal Price{ get; set; }
        public int Quantity { get; set; }

        //public IList<BookGenre> BookGenres { get; set; }


    }
}
