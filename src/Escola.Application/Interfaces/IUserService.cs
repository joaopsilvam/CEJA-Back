using Enceja.Domain.Entities;

namespace Enceja.Domain.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
