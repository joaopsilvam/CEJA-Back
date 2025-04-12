using Microsoft.EntityFrameworkCore;
using Enceja.Domain.Entities;

namespace Enceja.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Teacher_Subject> Teachers_Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher_Subject>()
            .HasKey(pd => new { pd.TeacherId, pd.SubjectId });

            modelBuilder.Entity<Teacher_Subject>()
            .HasOne(pd => pd.Teacher)
            .WithMany(p => p.Teachers_Subjects)
            .HasForeignKey(pd => pd.TeacherId);

            modelBuilder.Entity<Teacher_Subject>()
            .HasOne(pd => pd.Subject)
            .WithMany(d => d.Teachers_Subjects)
            .HasForeignKey(pd => pd.SubjectId);
        }
    }
}
