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
        public DbSet<Teacher_Class> Teachers_Class { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().ToTable("student");
            modelBuilder.Entity<User>().ToTable("user");

            //modelBuilder.Entity<Student>()
            //.HasOne(s => s.Class)
            //.WithMany(c => c.Students)
            //.HasForeignKey(s => s.ClassId);

            //Teacher_Subject
            modelBuilder.Entity<Teacher_Subject>()
            .HasKey(tc => new { tc.TeacherId, tc.SubjectId });

            modelBuilder.Entity<Teacher_Subject>()
            .HasOne(ts => ts.Teacher)
            .WithMany(t => t.Teachers_Subjects)
            .HasForeignKey(ts => ts.TeacherId);

            modelBuilder.Entity<Teacher_Subject>()
            .HasOne(ts => ts.Subject)
            .WithMany(s => s.Teachers_Subjects)
            .HasForeignKey(ts => ts.SubjectId);

            //Teacher_Class
            modelBuilder.Entity<Teacher_Class>()
            .HasKey(tc => new { tc.TeacherId, tc.ClassId });

            modelBuilder.Entity<Teacher_Class>()
            .HasOne(tc => tc.Teacher)
            .WithMany(t => t.Teachers_Class)
            .HasForeignKey(tc => tc.TeacherId);

            modelBuilder.Entity<Teacher_Class>()
            .HasOne(tc => tc.Class)
            .WithMany(c => c.Teachers_Class)
            .HasForeignKey(tc => tc.ClassId);
        }
    }
}
