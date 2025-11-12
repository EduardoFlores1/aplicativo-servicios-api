using Caja.Servicios.Domain.Entities.Usuario;
using Caja.Servicios.Domain.Models.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Caja.Servicios.Application.Features.Jwt
{
    public class JwtService : IJwtService
    {

        private readonly JwtSettings _jwtSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtService(IOptions<JwtSettings> options, IHttpContextAccessor httpContextAccessor)
        {
            _jwtSettings = options.Value;
            _httpContextAccessor = httpContextAccessor;
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
                expires: DateTime.Now.AddMinutes(180),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Guid ObtenerPublicIdByToken()
        {

            try {

                var user = _httpContextAccessor.HttpContext?.User;

                var sub = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (sub.IsNullOrEmpty()) return Guid.Empty;

                Console.WriteLine("sub ->: " + sub);

                return Guid.Parse(sub!);

            } catch (System.Exception) { 
                   
                return Guid.Empty;
            }

        }
    }
}
