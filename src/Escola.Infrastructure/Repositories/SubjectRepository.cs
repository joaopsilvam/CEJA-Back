﻿using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;

namespace Enceja.Infrastructure.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
