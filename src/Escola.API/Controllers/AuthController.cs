using Enceja.Domain.Services;
using Enceja.Appplication.DTOs;
using Enceja.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using Enceja.Application.DTOs;

namespace Enceja.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IUserService _userService;

        public AuthController(TokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);

            if (user.Email != request.Email && user.Password != user.Password)
            {
                return Unauthorized(new { Message = "Usuário ou senha inválidos" });
            }

            var token = _tokenService.GenerateToken(user.Email, "User", request.RememberMe);
            return Ok(new { Token = token, User = user });
        }

        [HttpPost("sign-in-with-token")]
        public async Task<IActionResult> SignInWithToken([FromBody] TokenDTO dto)
        {
            var accessToken = dto?.AccessToken;

            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized(new { message = "Token não fornecido" });

            var handler = new JwtSecurityTokenHandler();

            try
            {
                var token = handler.ReadJwtToken(accessToken);
                var email = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                if (string.IsNullOrEmpty(email))
                    return Unauthorized(new { message = "Token inválido" });

                var user = await _userService.GetByEmailAsync(email);

                if (user == null)
                    return Unauthorized(new { message = "Usuário não encontrado" });

                return Ok(new
                {
                    User = user
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao validar token", detail = ex.Message });
            }
        }


    }
}
