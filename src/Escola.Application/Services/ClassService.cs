using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Enceja.Domain.Interfaces.Repositories;

namespace Enceja.Domain.Services
{
    public class ClassService : BaseService<Class>, IClassService
    {
        public ClassService(IBaseRepository<Class> repository) : base(repository)
        {
        }
    }
}
