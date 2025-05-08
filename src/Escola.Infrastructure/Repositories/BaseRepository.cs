using Enceja.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Enceja.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByCpfAsync(string cpf)
        {
            return await _dbSet.FindAsync(cpf);
        }

        public async Task UpdateAsync(T entity)
        {
            var existingEntity = await _dbSet.FindAsync(_context.Entry(entity).Property("Id").CurrentValue);

            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task ReloadAsync(T entity)
        {
            await _context.Entry(entity).ReloadAsync();
        }

        public Task DetachAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            return Task.CompletedTask;
        }
    }
}
