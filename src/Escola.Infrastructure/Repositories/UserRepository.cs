﻿using Enceja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Enceja.Domain.Interfaces;

namespace Enceja.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}