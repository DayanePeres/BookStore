using BookStore.Data.Context;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repository
{
    public class AuthorRepository : BaseRepository<AuthorEntity> , IAuthorRepository
    {
        public AuthorRepository(MyContext context) : base(context)
        {

        }
    }
}
