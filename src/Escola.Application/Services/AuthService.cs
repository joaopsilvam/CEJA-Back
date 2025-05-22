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
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IEmailService _emailService;
        private readonly TokenService _tokenService;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;
        private readonly IPasswordHasher<string> _passwordHasher;

        public AuthService(
            IUserService userService,
            IEmailService emailService,
            TokenService tokenService,
            IStudentService studentService,
            ITeacherService teacherService,
            IWebHostEnvironment env,
            IConfiguration config,
            IPasswordHasher<string> passwordHasher)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _userService = userService;
            _emailService = emailService;
            _tokenService = tokenService;
            _env = env;
            _config = config;
            _passwordHasher = passwordHasher;
        }

        public async Task<object> LoginAsync(LoginDTO request)
        {
            try
            {
                object entity;
                if (request.RoleId == 3)
                {
                    entity = await _studentService.GetByEmailAsync(request.Email);
                }
                else if (request.RoleId == 2)
                {
                    entity = await _teacherService.GetByEmailAsync(request.Email);
                }
                else
                {
                    entity = await _userService.GetByEmailAsync(request.Email);
                }

                if (entity == null)
                    throw new UnauthorizedAccessException("Usuário não encontrado.");

                return await AuthenticateEntityAsync(entity, request.Password, request.RememberMe);
            }
            catch (Exception error)
            {
                return error;
            }
        }

        private async Task<object> AuthenticateEntityAsync(object entity, string password, bool rememberMe)
        {
            string email;
            string hashedPassword;
            int roleId;

            try
            {

                // Extrai os dados da entidade
                switch (entity)
                {
                    case Student student:
                        email = student.Email;
                        hashedPassword = student.Password;
                        roleId = 3;
                        break;
                    case Teacher teacher:
                        email = teacher.Email;
                        hashedPassword = teacher.Password;
                        roleId = 2;
                        break;
                    case User user:
                        email = user.Email;
                        hashedPassword = user.Password;
                        roleId = user.RoleId;
                        break;
                    default:
                        throw new InvalidOperationException("Entidade não suportada.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao extrair dados da entidade.", ex);
            }


            // Valida a senha
            var passwordValid = _passwordHasher.VerifyHashedPassword(email, hashedPassword, password);
            if (passwordValid != PasswordVerificationResult.Success)
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");

            // Gera o token
            var token = _tokenService.GenerateToken(email, roleId, rememberMe);

            return new { Token = token, User = entity };
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
