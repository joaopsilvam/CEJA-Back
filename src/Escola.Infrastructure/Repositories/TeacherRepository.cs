﻿using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.Infrastructure.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
