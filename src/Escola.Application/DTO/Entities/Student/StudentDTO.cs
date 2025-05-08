namespace Enceja.Application.DTO.Entities.Student
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime BornDate { get; set; }
        public int? ClassId { get; set; }
        public int RegistrationNumber { get; set; }

        public ClassDTO? Class { get; set; }

        public RoleType Role { get; set; }
    }
}
