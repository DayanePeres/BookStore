using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class AuthorEntity : BaseEntity
    {
        public string Name { get; set; }
        public IList<BookAuthorEntity> ListBookAuthor { get; set; }
    }
}
