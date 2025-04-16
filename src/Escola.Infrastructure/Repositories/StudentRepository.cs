using Enceja.Application.DTO.Entities;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<IEnumerable<Student>> GetStudentByClass(int classId)
        {
            return await _context.Students
                       .Include(s => s.Class)
                       .Where(s => s.ClassId == classId)
                       .ToListAsync();
            //var studentsReturn = await _context.Students
            //    .Include(s => s.Class)
            //    .Where(s => s.ClassId == classId)
            //    .ToListAsync();

            //var dtos = studentsReturn.Select(s => new StudentDTO
            //{
            //    ClassId = s.ClassId,
            //    RegistrationNumber = s.RegistrationNumber
            //}).ToList();

            //return dtos;

            //return await _context.Students.ToListAsync();
            //return await _context.Students.Where(s => s.ClassId == classId).ToListAsync();
        }
    }
}
