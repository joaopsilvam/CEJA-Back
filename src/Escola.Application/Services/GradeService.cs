using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Enceja.Domain.Interfaces.Repositories;

namespace Enceja.Domain.Services
{
    public class GradeService : BaseService<Grade>, IGradeService
    {
        public GradeService(IBaseRepository<Grade> repository) : base(repository)
        {
        }
    }
}
