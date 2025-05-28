using Enceja.Application.DTO.Entities.Grade;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.Domain.Services
{
    public class GradeService : BaseService<Grade>, IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IBaseRepository<Grade> repository, IGradeRepository gradeRepository) : base(repository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<IEnumerable<GradeDTO>> GetGradeBySubjectOfStudent(int studentId)
        {
            var grades = await _gradeRepository.GetGradeBySubjectOfStudent(studentId);

            var gradeDTO = grades.Select(g => new GradeDTO
            {
                Id = g.Id,
                GradeValue = g.GradeValue,
                StudentName = g.Student.Name,
                SubjectName = g.Subject.Name
            });

            return gradeDTO;
        }
    }
}
