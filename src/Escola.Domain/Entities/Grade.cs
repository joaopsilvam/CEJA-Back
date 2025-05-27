using System.ComponentModel.DataAnnotations.Schema;

namespace Enceja.Domain.Entities
{
    [Table("grade")]
    public class Grade
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }

        [Column("subject_id")]
        public int SubjectId { get; set; }

        [Column("grade_value")]
        public int GradeValue { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }
        
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; }
    }
}
