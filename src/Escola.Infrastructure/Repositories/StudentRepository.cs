using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enceja.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Student>> GetAllStudentsWithClass()
        {
           return await _context.Students
                .Include(s => s.Class)
                .Where(s=> s.ClassId != null)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentByClass(int classId)
        {
            return await _context.Students
                       .Include(s => s.Class)
                       .Where(s => s.ClassId == classId)
                       .ToListAsync();
        }
    }
}
