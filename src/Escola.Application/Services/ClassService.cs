using Enceja.Application.DTO.Entities.Class;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Enceja.Application.DTO.Entities.Student;
using Enceja.Application.DTO.Entities.Teacher;

namespace Enceja.Domain.Services
{
    public class ClassService : BaseService<Class>, IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IBaseRepository<Student> _studentRepository;

        public ClassService(IClassRepository classRepository, IBaseRepository<Student> studentRepository) : base(classRepository)
        {
            _classRepository = classRepository;
            _studentRepository = studentRepository;
        }

        public async Task AddStudentToClassAsync(int classId, int studentId)
        {
            var turma = await _classRepository.GetWithStudentsAsync(classId);
            var aluno = await _studentRepository.GetByIdAsync(studentId);

            if (turma == null || aluno == null)
                throw new Exception("Turma ou Aluno não encontrado");

            turma.Students ??= new List<Student>();

            if (!turma.Students.Any(s => s.Id == studentId))
            {
                turma.Students.Add(aluno);
                await _classRepository.UpdateAsync(turma);
            }
        }

        public async Task<ClassGetByIdWithStudentsDTO> GetByIdWithStudentsAsync(int id)
        {
            var turma = await _classRepository
                .GetQueryable()
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (turma == null)
                throw new Exception("Turma não encontrada");

            return new ClassGetByIdWithStudentsDTO
            {
                Id = turma.Id,
                Year = turma.Year,
                Shift = (int)turma.Shift,
                Suffix = turma.Suffix,
                EducationLevel = (int)turma.EducationLevel,
                Students = turma.Students?.Select(s => new StudentDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    RegistrationNumber = s.RegistrationNumber
                }).ToList() ?? new List<StudentDTO>()
            };
        }

        public async Task<ClassGetByIdWithTeachersDTO> GetByIdWithTeachersAsync(int id)
        {
            var turma = await _classRepository
                .GetQueryable()
                .Include(c => c.Teachers_Class)
                    .ThenInclude(tc => tc.Teacher)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (turma == null)
                throw new Exception("Turma não encontrada");

            return new ClassGetByIdWithTeachersDTO
            {
                Id = turma.Id,
                Year = turma.Year,
                Shift = (int)turma.Shift,
                Suffix = turma.Suffix,
                EducationLevel = (int)turma.EducationLevel,
                Teachers = turma.Teachers_Class?
                    .Select(tc => new TeacherDTO
                    {
                        Id = tc.Teacher.Id,
                        Name = tc.Teacher.Name,
                        Email = tc.Teacher.Email
                    }).ToList() ?? new List<TeacherDTO>()
            };
        }


    }
}
