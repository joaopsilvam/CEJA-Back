using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enceja.Domain.Entities
{
    public enum Periodo
    {
        Manha = 1,
        Tarde = 2,
        Noite = 3
    }
    
    [Table("class")]
    public class Class
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("year")]
        public int Ano { get; set; }

        [Column("period")]
        public Periodo Periodo { get; set; }

         [Column("suffix")]
        public string Suffix { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ICollection<Student>? Students { get; set; }
        public ICollection<Teacher_Class> Teachers_Class { get; set; }
    }
}
