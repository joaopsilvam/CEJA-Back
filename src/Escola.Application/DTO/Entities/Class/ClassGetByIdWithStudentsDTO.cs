
namespace Enceja.Application.DTO.Entities.Class
{
    public class ClassGetByIdWithStudentsDTO
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Shift { get; set; }
        public string Suffix { get; set; }
        public int EducationLevel { get; set; }

        public List<StudentDTO> Students { get; set; }
    }

}
