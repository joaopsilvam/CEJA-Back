
using System.ComponentModel.DataAnnotations.Schema;

namespace Enceja.Domain.Entities
{
    [Table("teacher_class")]
    public class Teacher_Class
    {
        [Column("teacher_id")]
        public int TeacherId { get; set; }

        [Column("class_id")]
        public int ClassId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }

        [ForeignKey(nameof(ClassId))]
        public Class Class { get; set; }
    }
}
