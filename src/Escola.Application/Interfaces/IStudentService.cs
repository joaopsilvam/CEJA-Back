﻿using Enceja.Application.DTO.Entities;
using Enceja.Domain.Entities;

namespace Enceja.Domain.Interfaces
{
    public interface IStudentService : IBaseService<Student>
    {
        Task<IEnumerable<StudentDTO>> GetStudentByClass(int classId);
        Task<IEnumerable<StudentDTO>> GetAllStudentsWithClass();
    }
}
