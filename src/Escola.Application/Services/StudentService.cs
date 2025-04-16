using Enceja.Application.DTO.Entities;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.Domain.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository; 
        public StudentService(IBaseRepository<Student> repository, IStudentRepository studentRepository) : base(repository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDTO>> GetStudentByClass(int classId)
        {
            var students = await _studentRepository.GetStudentByClass(classId);

            var dtos = students.Select(s => new StudentDTO
            {
                ClassId = s.ClassId,
                RegistrationNumber = s.RegistrationNumber
            });

            return dtos;
        }
    }
}
