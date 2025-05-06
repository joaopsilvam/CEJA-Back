using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.Domain.Services
{
    public class GradeService : BaseService<Grade>, IGradeService
    {
        private readonly IGradeRepository  _gradeRepository;

        public GradeService(IBaseRepository<Grade> repository, IGradeRepository gradeRepository) : base(repository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<IEnumerable<Grade>> GetGradeBySubjectOfStudent(int studentId)
        {
           return await _gradeRepository.GetGradeBySubjectOfStudent(studentId);
        }
    }
}
