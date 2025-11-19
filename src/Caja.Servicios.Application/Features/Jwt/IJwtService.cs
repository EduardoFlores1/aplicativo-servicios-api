using Caja.Servicios.Domain.Entities.Usuario;

namespace Caja.Servicios.Application.Features.Jwt
{
    public interface IJwtService
    {
       string GenerarToken(UsuarioEntity usuarioEntity);
       Guid ObtenerPublicIdByToken();
    }
}
