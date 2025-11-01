using Microsoft.EntityFrameworkCore;

namespace Caja.Servicios.Application.DataBase.Solicitud.Commands.ActualizarSolicitud
{
    public class ActualizarSolicitudCommand: IActualizarSolicitudCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public ActualizarSolicitudCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<ActualizarSolicitudResponse> ExecuteAsync(ActualizarSolicitudRequest request) { 
            
            var entity = await _dataBaseService.Solicitudes
                .Where(s => s.PublicID == request.PublicID && !s.IsDeleted)
                .FirstOrDefaultAsync() ?? throw new InvalidOperationException("Solicitud no encontrada: " + request.PublicID);

            entity.DetalleSolicitud = request.DetalleSolicitud;
            entity.UpdatedAt = DateTime.Now;
            entity.IsUpdated = true;

            await _dataBaseService.SaveAsync();

            var response = new ActualizarSolicitudResponse
            {
                PublicID = entity.PublicID,
                DetalleSolicitud = entity.DetalleSolicitud,
                UpdatedAt = entity.UpdatedAt
            };

            return response;
        }
    }
}
