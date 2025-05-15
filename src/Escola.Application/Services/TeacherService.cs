using Enceja.Domain.Services;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.Domain.Services
{
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(IBaseRepository<Teacher> repository, ITeacherRepository teacherRepository) : base(repository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task ApproveTeacherAsync(int teacherId)
        {
            await _teacherRepository.ApproveTeacherAsync(teacherId);
        }
    }
}
