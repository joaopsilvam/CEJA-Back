using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Enceja.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByCpfAsync(string cpf);
        Task<T> GetByEmailAsync(string email);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQueryable();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task ReloadAsync(T entity);
        Task DetachAsync(T entity);
        Task AddWithoutSaveAsync(T entity);
        Task SaveChangesAsync();
    }
}
