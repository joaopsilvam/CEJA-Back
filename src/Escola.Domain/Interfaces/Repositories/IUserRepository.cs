using Enceja.Domain.Entities;
using System.Threading.Tasks;

namespace Enceja.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
