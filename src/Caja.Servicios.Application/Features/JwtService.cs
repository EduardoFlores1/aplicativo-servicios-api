using Caja.Servicios.Domain.Entities.Usuario;
using Caja.Servicios.Domain.Models.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Caja.Servicios.Application.Features
{
    public class JwtService : IJwtService
    {

        private readonly JwtSettings _jwtSettings;

        public JwtService(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public string GenerarToken(UsuarioEntity usuarioEntity)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                // Sub es el PublicUserID del Usuario
            new Claim(JwtRegisteredClaimNames.Sub, usuarioEntity.PublicID.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, usuarioEntity.Email.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
