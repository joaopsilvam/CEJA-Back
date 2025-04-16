using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.Domain.Services
{
    public class ClassService : BaseService<Class>, IClassService
    {
        public ClassService(IBaseRepository<Class> repository) : base(repository)
        {
        }
    }
}
