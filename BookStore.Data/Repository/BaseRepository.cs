using BookStore.Data.Context;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MyContext _myContext;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(MyContext myContext)
        {
            _myContext = myContext;
            _dbSet = _myContext.Set<TEntity>();
        }

        public async Task<TEntity> Create(TEntity obj)
        {
            try
            {
                if(obj.Id == Guid.Empty)
                {
                    obj.Id = Guid.NewGuid();
                }
                obj.CreateAt = DateTime.UtcNow;
                _dbSet.Add(obj);
                await _myContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return obj;
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (result == null)
                    return false;

                _dbSet.Remove(result);
                await _myContext.SaveChangesAsync();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<TEntity> Select(Guid id)
        {
            try
            {
                return await _dbSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<TEntity>> SelectAll()
        {
          
                return await _dbSet.ToListAsync();
          
        }

        public async Task<TEntity> Update(TEntity obj)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(p => p.Id.Equals(obj.Id));
                if (result == null)
                    return null;

                obj.UpdateAt = DateTime.UtcNow;
                obj.CreateAt = result.CreateAt;

                _myContext.Entry(result).CurrentValues.SetValues(obj);
                
                await _myContext.SaveChangesAsync();
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
