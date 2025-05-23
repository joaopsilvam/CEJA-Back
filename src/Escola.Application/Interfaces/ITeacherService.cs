﻿using Enceja.Domain.Entities;

namespace Enceja.Domain.Interfaces
{
    public interface ITeacherService : IBaseService<Teacher>
    {
        Task ApproveTeacherAsync(int teacherId);
    }
}
