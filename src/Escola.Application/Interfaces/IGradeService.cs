using Enceja.Application.DTO.Entities.Grade;
using Enceja.Domain.Entities;

namespace Enceja.Domain.Interfaces
{
    public interface IGradeService : IBaseService<Grade>
    {
        Task<IEnumerable<GradeDTO>> GetGradeBySubjectOfStudent(int studentId);
    }
}
