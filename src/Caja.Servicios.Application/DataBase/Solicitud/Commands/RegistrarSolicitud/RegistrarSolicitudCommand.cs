using Caja.Servicios.Application.Features.Jwt;
using Caja.Servicios.Domain.Entities.Solicitud;
using Microsoft.EntityFrameworkCore;

namespace Caja.Servicios.Application.DataBase.Solicitud.Commands.RegistrarSolicitud
{
    public class RegistrarSolicitudCommand: IRegistrarSolicitudCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IJwtService _jwtService;

        public RegistrarSolicitudCommand(
            IDataBaseService dataBaseService,
            IJwtService jwtService)
        {
            _dataBaseService = dataBaseService;
            _jwtService = jwtService;
        }

        public async Task<RegistrarSolicitudResponse> ExecuteAsync(RegistrarSolicitudRequest request) {

            

            var publicUsuarioIDJWT = _jwtService.ObtenerPublicIdByToken();

            if (publicUsuarioIDJWT == Guid.Empty) { 
                throw new InvalidOperationException("Claim sub no disponible");
            }

            var usuarioID = await _dataBaseService.Usuarios
                .Where(u => u.PublicID == publicUsuarioIDJWT)
                .Select(u => (int?)u.UsuarioID)
                .FirstOrDefaultAsync() ?? throw new InvalidOperationException("El usuario solicitante es inválido.");

            var fecha = DateTime.Now;

            var newSolicitud = new SolicitudEntity
            {
                UsuarioID = usuarioID,
                DetalleSolicitud = request.DetalleSolicitud,
                CreatedAt = fecha,
                UpdatedAt = fecha,
                IsUpdated = false,
                IsDeleted = false
            };

            await _dataBaseService.Solicitudes.AddAsync(newSolicitud);
            await _dataBaseService.SaveAsync();

            var response = new RegistrarSolicitudResponse
            {
                PublicUsuarioRegistraID = publicUsuarioIDJWT,
                DetalleSolicitud = request.DetalleSolicitud,
                CreateAt = newSolicitud.CreatedAt
            };

            return response;
        }
    }
}
