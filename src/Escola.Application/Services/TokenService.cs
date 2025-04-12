using Enceja.Domain.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Enceja.Domain.Services
{
    public class TokenService
    {
        private readonly string _secretKey;

        public TokenService()
        {
            _secretKey = JwtSecretKey.GenerateSecretKey();
        }

        public string GenerateToken(string email, string role, bool rememberMe)
        {
            var keyBytes = JwtSecretKey.GetKeyBytes(_secretKey);
            var key = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var expires = rememberMe
                ? DateTime.UtcNow.AddDays(30)
                : DateTime.UtcNow.AddHours(2);

            var token = new JwtSecurityToken(
                issuer: "Enceja.API",
                audience: "Enceja.API",
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
