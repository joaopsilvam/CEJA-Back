using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces.Repositories;

namespace Enceja.Infrastructure.Repositories
{
    public class TurmaRepository : BaseRepository<Class>, IClassRepository
    {
        public TurmaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
