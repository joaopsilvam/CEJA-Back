using Enceja.Domain.Services;
using Enceja.Domain.Interfaces.Repositories;
using Enceja.Domain.Interfaces;
using Enceja.Domain.Entities;

namespace Enceja.Application.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _usuarioRepository;

        public UserService(IUserRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email);
        }
    }
}
