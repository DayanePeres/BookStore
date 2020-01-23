using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Mapping
{
    public class BookGenreMap : IEntityTypeConfiguration<BookGenreEntity>
    {
        public void Configure(EntityTypeBuilder<BookGenreEntity> builder)
        {
            //Tabela de LivroAutor (n:n)
            builder.ToTable("BookGenre");

            builder.HasKey(bg => new { bg.BookId, bg.GenreId });

            builder.HasOne<BookEntity>(bg => bg.Book)
              .WithMany(bg => bg.ListBookGenres);

            builder.HasOne<GenreEntity>(bg => bg.Genre)
                .WithMany(bg => bg.ListBookGenres);

        }
    }
}
