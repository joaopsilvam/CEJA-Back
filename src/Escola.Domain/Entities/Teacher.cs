using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enceja.Domain.Entities
{
    [Table("teacher")]
    public class Teacher
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

        [Column("password_reset_token")]
        public string PasswordResetToken { get; set; }

        [Column("password_reset_token_expiry")]
        public DateTime? PasswordResetTokenExpiry { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
         
        public ICollection<Teacher_Subject> Teachers_Subjects { get; set; }
        public ICollection<Teacher_Class> Teachers_Class { get; set; }
    }
}
