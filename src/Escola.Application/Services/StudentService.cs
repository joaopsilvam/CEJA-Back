using Enceja.Application.DTO.Entities;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsWithClass()
        {
            var students = await _studentRepository.GetAllStudentsWithClass();

            var studentDtos = students.Select(s => new StudentDTO
            {
                Id = s.Id,
                ClassId = s.ClassId,
                Name = s.Name,
                RegistrationNumber = s.RegistrationNumber,
                Class = s.Class != null ? new ClassDTO
                {
                    Id = s.Class.Id,
                    Year = s.Class.Year,
                    Shift = s.Class.Shift,
                    Suffix = s.Class.Suffix,
                    EducationLevel = s.Class.EducationLevel
                } : null
            });

            return studentDtos;
        }

    }
}
