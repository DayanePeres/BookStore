using BookStore.Data.Mapping;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorEntity>(new AuthorMap().Configure);
            modelBuilder.Entity<BookEntity>(new BookMap().Configure);
            modelBuilder.Entity<BookGenreEntity>(new BookGenreMap().Configure);            
            modelBuilder.Entity<GenreEntity>(new GenreMap().Configure);
            modelBuilder.Entity<BookAuthorEntity>(new BookAuthorMap().Configure);

        }
        
    }
}
