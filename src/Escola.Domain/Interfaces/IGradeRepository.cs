using Enceja.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enceja.Domain.Interfaces
{
    public interface IGradeRepository : IBaseRepository<Grade>
    {
        Task<IEnumerable<Grade>> GetGradeBySubjectOfStudent(int studentId);
    }
}
