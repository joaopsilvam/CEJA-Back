using System;
using System.ComponentModel.DataAnnotations.Schema;
public enum RoleType
{
    Student = 1,
    Teacher = 2,
    Admin = 3,
    PendingTeacher = 4
}

namespace Enceja.Domain.Entities
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }

        public string Avatar { get; set; }

        public string Name { get; set; }

        public string Email { get; set; } 

        public string Document { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime BornDate { get; set; }

        public string PasswordResetToken { get; set; }

        public DateTime? PasswordResetTokenExpiry { get; set; }

        public RoleType Role { get; set; }
    }
}