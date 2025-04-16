using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.Domain.Services
{
    public class GradeService : BaseService<Grade>, IGradeService
    {
        public GradeService(IBaseRepository<Grade> repository) : base(repository)
        {
        }
    }
}
