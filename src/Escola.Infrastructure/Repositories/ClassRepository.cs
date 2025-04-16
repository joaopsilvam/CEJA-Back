using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.Infrastructure.Repositories
{
    public class TurmaRepository : BaseRepository<Class>, IClassRepository
    {
        public TurmaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
