using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enceja.Domain.Entities
{
    [Table("teacher")]
    public class Teacher : User
    {
        public ICollection<Teacher_Subject> Teachers_Subjects { get; set; }
        public ICollection<Teacher_Class> Teachers_Class { get; set; }
    }
}
