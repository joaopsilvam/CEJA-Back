using Enceja.Application.DTO.Entities.Student;
using Enceja.Domain.Entities;

namespace Enceja.Domain.Interfaces
{
    public interface IStudentService : IBaseService<Student>
    {
        Task<IEnumerable<StudentDTO>> GetStudentByClass(int classId);
        Task<int> GenerateRegistrationNumberAsync(string cpf);
        Task<IEnumerable<StudentDTO>> GetAllStudentsWithClass();
    }
}
