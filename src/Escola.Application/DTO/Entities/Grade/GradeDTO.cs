namespace Enceja.Application.DTO.Entities.Grade
{
    public class GradeDTO
    {
        public int Id { get; set; }
        public int GradeValue { get; set; }
        public required string StudentName { get; set; }
        public required string SubjectName { get; set; }
    }
}
