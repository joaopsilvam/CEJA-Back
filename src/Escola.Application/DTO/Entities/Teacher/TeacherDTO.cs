namespace Enceja.Application.DTO.Entities.Teacher
{
    public class TeacherDTO
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
        public int RoleId { get; set; }
    }
}
