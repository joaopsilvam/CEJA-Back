using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces.Repositories;
using Enceja.Domain.Interfaces;

namespace Enceja.Domain.Services
{
    public class SubjectService : BaseService<Subject>, ISubjectService
    {
        public SubjectService(IBaseRepository<Subject> repository) : base(repository)
        {
        }
    }
}
