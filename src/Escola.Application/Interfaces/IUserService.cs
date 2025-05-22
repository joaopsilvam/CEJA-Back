using Enceja.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Enceja.Domain.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
