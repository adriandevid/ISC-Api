using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC.Api.Web.Services
{
    public static class JwtService
    {
        public static string GenerateToken(UsuarioDto user, IConfiguration Configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["JwtToken:Token"]);
            var Role = GetClaimTypeUser(user.TipoUsuario);

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
    }
}
