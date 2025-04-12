using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual string Address { get; set; }

        public DateTime BornDate { get; set; }
    }
}