using Enceja.Application.DTO.Entities.Grade;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enceja.Infrastructure.Repositories
{
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Grade>> GetGradeBySubjectOfStudent(int studentId)
        {
            var retorno = await _context.Grades
                                     .Where(g => g.StudentId == studentId)
                                     .Include(g => g.Student)
                                     .Include(g => g.Subject)
                                     .ToListAsync();

            return retorno;
        }
    }
}
