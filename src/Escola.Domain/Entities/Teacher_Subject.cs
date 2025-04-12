using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enceja.Domain.Entities
{
    [Table("teacher_subject")]
    public class Teacher_Subject
    {
        [Column("teacher_id")]
        public int TeacherId { get; set; }

        [Column("subject_id")]
        public int SubjectId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public Subject Subject { get; set; }
    }
}
