using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Mapping
{
    public class BookAuthorMap : IEntityTypeConfiguration<BookAuthorEntity>
    {
        public void Configure(EntityTypeBuilder<BookAuthorEntity> builder)
        {
            //Tabela de LivroAutor (n:n)
            builder.ToTable("BookAuthor");

            builder.HasKey(bg => new { bg.BookId, bg.AuthorId });

            builder.HasOne<BookEntity>(bg => bg.Book)
                .WithMany(bg => bg.ListBookAuthor);

            builder.HasOne<AuthorEntity>(bg => bg.Author)
                .WithMany(bg => bg.ListBookAuthor);
        }
    }
}
