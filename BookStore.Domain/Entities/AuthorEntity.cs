using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class AuthorEntity : BaseEntity
    {
        public string Name { get; set; }
        public IList<BookAuthorEntity> ListBookAuthor { get; set; }
    }
}
