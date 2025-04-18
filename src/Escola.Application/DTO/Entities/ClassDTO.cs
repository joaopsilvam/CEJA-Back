using Enceja.Domain.Entities;

namespace Enceja.Application.DTO.Entities
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public Shift Shift { get; set; }
        public string Suffix { get; set; }
        public EducationLevel EducationLevel { get; set; }
    }
}
