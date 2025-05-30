﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Enceja.Domain.Entities
{
    [Table("subject")]
    public class Subject
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }

        public ICollection<Teacher_Subject> Teachers_Subjects { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }

        public ICollection<Grade> Grades { get; set; }

    }
}
