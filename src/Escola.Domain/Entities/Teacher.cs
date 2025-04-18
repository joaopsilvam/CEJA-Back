﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Enceja.Domain.Entities
{
    [Table("teacher")]
    public class Teacher : User
    {
        [JsonIgnore]
        public ICollection<Teacher_Subject> Teachers_Subjects { get; set; }
        public ICollection<Teacher_Class> Teachers_Class { get; set; }
    }
}
