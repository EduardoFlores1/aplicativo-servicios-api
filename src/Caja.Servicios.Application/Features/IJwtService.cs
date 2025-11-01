using Caja.Servicios.Domain.Entities.Usuario;

namespace Caja.Servicios.Application.Features
{
    public interface IJwtService
    {
       string GenerarToken(UsuarioEntity usuarioEntity);
    }
}
