using Caja.Servicios.Domain.Entities.Solicitud;
using Microsoft.EntityFrameworkCore;

namespace Caja.Servicios.Application.DataBase.Solicitud.Commands.RegistrarSolicitud
{
    public class RegistrarSolicitudCommand: IRegistrarSolicitudCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public RegistrarSolicitudCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<RegistrarSolicitudResponse> ExecuteAsync(RegistrarSolicitudRequest request) {

            var usuarioID = await _dataBaseService.Usuarios
                .Where(u => u.PublicID == request.PublicUsuarioID)
                .Select(u => (int?)u.UsuarioID)
                .FirstOrDefaultAsync() ?? throw new Exception("El usuario solicitante es inválido."); ;

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
                PublicUsuarioID = request.PublicUsuarioID,
                DetalleSolicitud = request.DetalleSolicitud,
                CreateAt = newSolicitud.CreatedAt
            };

            return response;
        }
    }
}
