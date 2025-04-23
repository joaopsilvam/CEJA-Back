using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Enceja.Infrastructure.Repositories
{
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Class> GetWithStudentsAsync(int classId)
        {
            return await _context.Set<Class>()
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == classId);
        }
    }
}
