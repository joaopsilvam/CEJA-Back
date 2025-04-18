using Enceja.Domain.Entities;

namespace Enceja.Application.DTO.Entities
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ClassId { get; set; }
        public int RegistrationNumber { get; set; }

        public ClassDTO? Class { get; set; }

    }
}
