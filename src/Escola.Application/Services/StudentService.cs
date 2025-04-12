using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Enceja.Domain.Interfaces.Repositories;

namespace Enceja.Domain.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(IBaseRepository<Student> repository) : base(repository)
        {
        }
    }
}
