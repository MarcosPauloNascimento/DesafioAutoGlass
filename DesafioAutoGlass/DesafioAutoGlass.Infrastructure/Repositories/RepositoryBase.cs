using DesafioAutoGlass.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly SqlDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        private bool disposed = false;

        protected RepositoryBase(SqlDbContext db)
        {
            _context = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public void Detach(Func<TEntity, bool> predicate)
        {
            var entity = _dbSet.Local.Where(predicate).FirstOrDefault();
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }

                disposed = true;
            }
        }
    }
}
