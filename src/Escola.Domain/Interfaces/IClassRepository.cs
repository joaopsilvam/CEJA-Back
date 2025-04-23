using Enceja.Domain.Entities;
using System.Threading.Tasks;

namespace Enceja.Domain.Interfaces
{
    public interface IClassRepository : IBaseRepository<Class>
    {
        Task<Class> GetWithStudentsAsync(int classId);
    }
}
