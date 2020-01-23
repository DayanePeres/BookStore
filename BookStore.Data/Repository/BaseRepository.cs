using BookStore.Data.Context;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MyContext _myContext;
        private DbSet<TEntity> dbSet;

        public Task Create(TEntity obj)
        {
            throw new NotImplementedException();
        }

        /* public Task Create(TEntity obj)
         {
            *//* try
             {
                 if(obj.Id.)
             }
             catch (Exception)
             {

                 throw;
             }*//*
         }*/

        public Task Delete(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Select(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> SelectAll()
        {
            return null;
        }

        public Task Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
