using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Enceja.Application.DTO;
using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Enceja.Domain.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Enceja.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly TokenService _tokenService;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AuthService(
            IUserService userService,
            IEmailService emailService,
            TokenService tokenService,
            IWebHostEnvironment env,
            IConfiguration config,
            IPasswordHasher<User> passwordHasher)
        {
            _userService = userService;
            _emailService = emailService;
            _tokenService = tokenService;
            _env = env;
            _config = config;
            _passwordHasher = passwordHasher;
        }

        public async Task<object> LoginAsync(LoginDTO request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);

            if (user == null)
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");

            var passwordValid = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

            if (passwordValid != PasswordVerificationResult.Success)
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");

            var token = _tokenService.GenerateToken(user.Email, "User", request.RememberMe);

            return new { Token = token, User = user };
        }

        public async Task<User> SignInWithTokenAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var email = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
                throw new UnauthorizedAccessException("Token inválido.");

            var user = await _userService.GetByEmailAsync(email);

            if (user == null)
                throw new UnauthorizedAccessException("Usuário não encontrado.");

            return user;
        }

        public async Task SendResetLinkAsync(string email)
        {
            var user = await _userService.GetByEmailAsync(email);

            if (user == null)
                throw new InvalidOperationException("Usuário não encontrado.");

            var token = Guid.NewGuid().ToString();
            user.PasswordResetToken = token;
            user.PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(1);
            await _userService.UpdateAsync(user);

            var baseResetUrl = _env.IsDevelopment()
                ? "http://localhost:4200/reset-password"
                : "https://ceja.netlify.app/reset-password";

            var resetUrl = $"{baseResetUrl}?token={token}&email={user.Email}";

            await _emailService.SendAsync(
                user.Email,
                "Redefinição de senha",
                $"Clique no link para redefinir sua senha: <a href='{resetUrl}'>{resetUrl}</a>");
        }

        public async Task ResetPasswordAsync(ResetPasswordDTO request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);

            if (user == null ||
                user.PasswordResetToken != request.Token ||
                user.PasswordResetTokenExpiry < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Token inválido ou expirado.");
            }

            var hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user, request.NewPassword);
            user.PasswordResetToken = null;
            user.PasswordResetTokenExpiry = null;

            await _userService.UpdateAsync(user);
        }
    }
}
