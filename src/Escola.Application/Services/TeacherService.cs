using Enceja.Domain.Services;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces.Repositories;
using Enceja.Domain.Interfaces;

namespace Enceja.Domain.Services
{
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        public TeacherService(IBaseRepository<Teacher> repository) : base(repository)
        {
        }
    }
}
