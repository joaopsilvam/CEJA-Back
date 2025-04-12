using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enceja.Domain.Entities
{
    [Table("class")]
    public class Class
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
