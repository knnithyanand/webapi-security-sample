using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Samples.WebApiSecurity.TokenService.Helpers
{
    public class TokenHelper
    {
        private readonly static SymmetricSecurityKey SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("long-16-char-length-secret-key"));

        public static string GenerateToken(string username)
        {
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Email, $"{username}@domain.com"),
            };

            var token = new JwtSecurityToken(
                            issuer: "Samples.WebApiSecurity.TokenService",
                            audience: "Samples.WebApiSecurity.Clients",
                            claims: claims,
                            notBefore: DateTime.Now,
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256)
                        );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}