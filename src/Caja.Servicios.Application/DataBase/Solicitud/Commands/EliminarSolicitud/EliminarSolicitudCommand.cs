using Caja.Servicios.Domain.Entities.SolicitudAutitoria;
using Microsoft.EntityFrameworkCore;

namespace Caja.Servicios.Application.DataBase.Solicitud.Commands.EliminarSolicitud
{
    public class EliminarSolicitudCommand: IEliminarSolicitudCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public EliminarSolicitudCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task ExecuteAsync(EliminarSolicitudRequest request) {

            var usuarioEliminaID = await _dataBaseService.Usuarios
                .Where(u => u.PublicID == request.PublicUsuarioEliminaID)
                .Select(u => (int?)u.UsuarioID)
                .FirstOrDefaultAsync() ?? throw new Exception("No se pudo encontrar al usuario: " + request.PublicUsuarioEliminaID);

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
