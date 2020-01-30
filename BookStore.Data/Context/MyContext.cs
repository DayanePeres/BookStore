using BookStore.Data.Mapping;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<AuthorEntity> authorEntities{ get; set; }
        public DbSet<BookEntity> bookEntities { get; set; }
        public DbSet<BookGenreEntity> bookGenreEntities { get; set; }
        public DbSet<GenreEntity> genreEntities { get; set; }
        public DbSet<BookAuthorEntity> bookAuthorEntities { get; set; }

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
