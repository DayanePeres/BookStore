using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DbBookStore;Trusted_Connection=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BookGenre>()
            //    .HasKey(bc => new { bc.BookId, bc.GenreId });
            //modelBuilder.Entity<Genre>()
            //    .HasOne(bc => bc.bookGenres)
            //    .WithMany(b => b.BookGenres);
            //modelBuilder.Entity<Book>()
            //    .HasOne(bc => bc.Genre)
            //    .WithMany(c => c.bookGenres);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres{ get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

    }
}
