

using ISC.Api.Domain.Dtos;
using ISC.Api.Domain.Entitys;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ISC.Api.Web.Services
{
    public static class JwtService
    {
        public static string GenerateToken(Usuario user, IConfiguration Configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["JwtToken:Token"]);
            var Role = GetClaimTypeUser(user.TipoUsuarioId);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login.ToString()),
                    new Claim(ClaimTypes.Role, Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static string GetClaimTypeUser(int type)
        {
            switch (type)
            {
                case 1:
                    return "Administrador";
                case 2:
                    return "Publico";
                default:
                    return "N";
            }
        }
    }
}
