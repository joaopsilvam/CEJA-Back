using Enceja.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Enceja.Application.DTO;

namespace Enceja.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            try
            {
                var result = await _authService.LoginAsync(request);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }

        [HttpPost("sign-in-with-token")]
        public async Task<IActionResult> SignInWithToken([FromBody] TokenDTO request)
        {
            try
            {
                var user = await _authService.SignInWithTokenAsync(request.AccessToken);
                return Ok(new { User = user });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO request)
        {
            try
            {
                await _authService.SendResetLinkAsync(request.Email);
                return Ok(new { Message = "E-mail de redefinição enviado com sucesso." });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO request)
        {
            try
            {
                await _authService.ResetPasswordAsync(request);
                return Ok(new { Message = "Senha redefinida com sucesso." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
