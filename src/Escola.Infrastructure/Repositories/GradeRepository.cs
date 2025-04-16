using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.Infrastructure.Repositories
{
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
