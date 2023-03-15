using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Agro.Shared.Data.Repos.Dictionary
{
    public class DictionaryRepo<TEntity> : IDictionaryRepo<TEntity> where TEntity : BaseDictionary
    {
        private readonly DbSet<TEntity> _objectSet = null;
        private readonly DataContext _context;
        public DictionaryRepo(DataContext context)
        {
            _objectSet = context.Set<TEntity>();
            _context = context;
        }

        public DictionaryRepo(DbSet<TEntity> objectSet)
        {
            _objectSet = objectSet;
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression != null)
            {
                return _objectSet.Where(expression);
            }
            return _objectSet.AsQueryable<TEntity>();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _objectSet.FindAsync(id);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _objectSet.AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task Update(TEntity entity)
        {
            _context.Update(entity);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> Base()
        {
            throw new NotImplementedException();
        }

        async Task<Guid> IBaseRepo<TEntity>.Add(TEntity entity)
        {
            await _objectSet.AddAsync(entity);
            await Save();
            return entity.Id;
        }

        public Task AddRange(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRange(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }
    }
}
