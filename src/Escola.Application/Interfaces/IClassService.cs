using Enceja.Application.DTO.Entities.Class;
using Enceja.Domain.Entities;

namespace Enceja.Domain.Interfaces
{
    public interface IClassService : IBaseService<Class>
    {
        Task AddStudentToClassAsync(int classId, int studentId);
        Task<ClassGetByIdWithStudentsDTO> GetByIdWithStudentsAsync(int id);
        Task<ClassGetByIdWithTeachersDTO> GetByIdWithTeachersAsync(int id);
    }
}
