using System.ComponentModel.DataAnnotations.Schema;

namespace Enceja.Domain.Entities
{
    public class Subject_Class
    {
        [Column("subject_id")]
        public int SubjectId { get; set; }

        [Column("class_id")]
        public int ClassId { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public Subject Subject { get; set; }

        [ForeignKey(nameof(ClassId))]
        public Class Class { get; set; }
    }
}
