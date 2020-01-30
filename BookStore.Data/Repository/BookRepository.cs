using BookStore.Data.Context;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookStore.Data.Repository
{
    public class BookRepository : BaseRepository<BookEntity>, IBookRepository
    {
        public BookRepository(MyContext context) : base(context)
        {

        }

        public object SelectAllWithAuthorAndGenre(Guid? id)
        {
            var query = _myContext.Set<BookEntity>()                
                .Select(obj => new
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    Price = obj.Price,
                    Quantity = obj.Quantity,
                    Authors = obj.ListBookAuthor.Select(author => author.Author),
                    Genre = obj.ListBookGenres.Select(genre => genre.Genre)
                });

            if(id != null)
            {
                return query.Where(p => p.Id == id).ToList();
            }

            return query.ToList();
        }

        public object SelectOneWithAuthorAndGenre(Guid id)
        {
            return SelectAllWithAuthorAndGenre(id);
        }
    }
}
