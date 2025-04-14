using Enceja.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Enceja.Domain.Entities
{
    [Table("student")]
    public class Student : User
    {
        [Column("class_id")]
        public int? ClassId { get; set; }

        [Column("registration_number")]
        public int RegistrationNumber { get; set; }

        [JsonIgnore]
        public ICollection<Grade> Grades { get; set; }

        [ForeignKey(nameof(ClassId))]
        public Class? Class { get; set; }
    }
}
