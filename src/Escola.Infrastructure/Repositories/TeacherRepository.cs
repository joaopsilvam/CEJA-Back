using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Enceja.Infrastructure.Repositories;
using Enceja.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
{
    private readonly ApplicationDbContext _context;

    public TeacherRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task ApproveTeacherAsync(int teacherId)
    {
        try
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == teacherId);

            if (teacher.RoleId == 4)
            {
                teacher.RoleId = 2;
                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao aprovar professor: {e.Message}");
        }

    }
}
