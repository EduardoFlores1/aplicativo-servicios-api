using Caja.Servicios.Application.Features.Jwt;
using Caja.Servicios.Domain.Entities.SolicitudAutitoria;
using Microsoft.EntityFrameworkCore;

namespace Caja.Servicios.Application.DataBase.Solicitud.Commands.EliminarSolicitud
{
    public class EliminarSolicitudCommand: IEliminarSolicitudCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IJwtService _jwtService;
        public EliminarSolicitudCommand(
            IDataBaseService dataBaseService,
            IJwtService jwtService)
        {
            _dataBaseService = dataBaseService;
            _jwtService = jwtService;
        }

        public async Task ExecuteAsync(EliminarSolicitudRequest request) {

            var publicUsuarioIDJWT = _jwtService.ObtenerPublicIdByToken();

            if (publicUsuarioIDJWT == Guid.Empty)
            {
                throw new InvalidOperationException("Claim sub no disponible");
            }

            var usuarioEliminaID = await _dataBaseService.Usuarios
                .Where(u => u.PublicID == publicUsuarioIDJWT)
                .Select(u => (int?)u.UsuarioID)
                .FirstOrDefaultAsync() ?? throw new InvalidOperationException("No se pudo encontrar al usuario solicitante");

            var solicitudEntity = await _dataBaseService.Solicitudes
                .FirstOrDefaultAsync(s => s.PublicID == request.PublicSolicitudID && !s.IsDeleted) 
                ?? throw new InvalidOperationException("Referencia Solicitud No Disponible: " + request.PublicSolicitudID);
            
            solicitudEntity.UpdatedAt = DateTime.Now;
            solicitudEntity.IsUpdated = true;
            solicitudEntity.IsDeleted = true;

            var solicitudAuditoriaEntity = new SolicitudAuditoriaEntity
            {
                SolicitudID = solicitudEntity.SolicitudID,
                UsuarioEliminaID = usuarioEliminaID,
                MotivoEliminacion = request.MotivoEliminacion,
                DeletedAt = solicitudEntity.UpdatedAt
            };

            await _dataBaseService.SolicitudAuditorias.AddAsync(solicitudAuditoriaEntity);

            await _dataBaseService.SaveAsync();
        }
    
    }
}
