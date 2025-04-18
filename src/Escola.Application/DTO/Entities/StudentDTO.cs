using Enceja.Domain.Entities;

namespace Enceja.Application.DTO.Entities
{
    public class StudentDTO
    {
        public string Name { get; set; }
        public int? ClassId { get; set; }
        public int RegistrationNumber { get; set; }

        public ClassDTO? Class { get; set; }

    }
}
