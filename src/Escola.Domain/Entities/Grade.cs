using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Column("teacher_id")]
        public int TeacherId { get; set; }

        [Column("grade_value")]
        public int GradeValue { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teacher { get; set; }
    }

}
