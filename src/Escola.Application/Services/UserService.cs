﻿using Enceja.Domain.Services;
using Enceja.Domain.Interfaces;
using Enceja.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Enceja.Application.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _usuarioRepository;

        public UserService(IUserRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _usuarioRepository.BeginTransactionAsync();
        }
    }
}
