using Enceja.Domain.Entities;
using System.Threading.Tasks;

namespace Enceja.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
