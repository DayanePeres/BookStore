﻿using System;

namespace BookStore.Domain.Entities
{
    public class BookAuthorEntity
    {
        public Guid BookId { get; set; }
        public virtual BookEntity Book { get; set; }
        public Guid AuthorId { get; set; }
        public virtual AuthorEntity Author { get; set; }
    }
}
