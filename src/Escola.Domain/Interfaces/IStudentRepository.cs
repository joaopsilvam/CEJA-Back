using Enceja.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enceja.Domain.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<IEnumerable<Student>> GetStudentByClass(int classId);
        Task<IEnumerable<Student>> GetAllStudentsWithClass();
    }
}
