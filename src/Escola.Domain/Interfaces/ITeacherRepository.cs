using Enceja.Domain.Entities;
using System.Threading.Tasks;

namespace Enceja.Domain.Interfaces
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        Task ApproveTeacherAsync(int teacherId);
    }
}
