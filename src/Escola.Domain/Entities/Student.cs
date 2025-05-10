using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Enceja.Domain.Entities
{
    [Table("student")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("avatar")]
        public string Avatar { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("document")]
        public string Document { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("born_date")]
        public DateTime BornDate { get; set; }

        [Column("registration_number")]
        public int RegistrationNumber { get; set; }

        [Column("password_reset_token")]
        public string PasswordResetToken { get; set; }

        [Column("password_reset_token_expiry")]
        public DateTime? PasswordResetTokenExpiry { get; set; }

        [Column("class_id")]
        public int? ClassId { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }

        [ForeignKey(nameof(ClassId))]
        public Class? Class { get; set; }

        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
