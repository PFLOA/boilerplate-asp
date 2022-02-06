using Coladel.Application.Handlers.Login.Request;
using Coladel.Domain.Entidades;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Coladel.JWT
{
    public static class RetornoJwt
    {
        public static string RetornoJwtString(Usuario result)
        {
            var secret = Encoding.ASCII.GetBytes("12b6fb24-adb8-4ce5-aa49-95a4sads4ad561sa");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()),
                   new Claim(ClaimTypes.Email, result.Email),
                   new Claim(ClaimTypes.Name, result.UserName),
                   new Claim(ClaimTypes.Uri, result.ConnectionString)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(tokenGenerated);
        }
    }
}
