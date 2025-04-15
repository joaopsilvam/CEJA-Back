using Enceja.Application.DTO;
using Enceja.Domain.Entities;

namespace Enceja.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<object> LoginAsync(LoginDTO request);
        Task<User> SignInWithTokenAsync(string token);
        Task SendResetLinkAsync(string email);
        Task ResetPasswordAsync(ResetPasswordDTO request);
    }
}
