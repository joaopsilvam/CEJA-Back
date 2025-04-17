using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Enceja.Domain.Entities
{
    public enum Shift
    {
        Manha = 1,
        Tarde = 2,
        Noite = 3
    }

    public enum EducationLevel
    {
        Fundamental = 1,
        Medio = 2,
        Infantil = 3
    }

    [Table("class")]
    public class Class
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("shift")]
        public Shift Shift { get; set; }

        [Column("suffix")]
        public string Suffix { get; set; }

        [Column("education_level")]
        public EducationLevel EducationLevel { get; set; }

        public ICollection<Student>? Students { get; set; }
        public ICollection<Teacher_Class>? Teachers_Class { get; set; }
    }
}
