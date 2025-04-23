using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enceja.Application.DTO.Entities.Class
{
    public class ClassGetByIdWithTeachersDTO
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Shift { get; set; }
        public string Suffix { get; set; }
        public int EducationLevel { get; set; }
        public List<TeacherDTO> Teachers { get; set; }
    }
}
