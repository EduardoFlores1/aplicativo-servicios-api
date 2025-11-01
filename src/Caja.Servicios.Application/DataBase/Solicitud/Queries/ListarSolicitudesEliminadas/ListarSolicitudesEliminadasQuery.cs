using Caja.Servicios.Domain.Models.Paginacion;
using Microsoft.EntityFrameworkCore;

namespace Caja.Servicios.Application.DataBase.Solicitud.Queries.ListarSolicitudesEliminadas
{
    public class ListarSolicitudesEliminadasQuery: IListarSolicitudesEliminadasQuery
    {
        private readonly IDataBaseService _dataBaseService;
        public ListarSolicitudesEliminadasQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<PaginadoResponse<ListarSolicitudesEliminadasResponse>> ExecuteAsync(PaginacionParams paginacionParams) {

            var queryBase = (from usuarioSolicitante in _dataBaseService.Usuarios
                                   join solicitud in _dataBaseService.Solicitudes
                                   on usuarioSolicitante.UsuarioID equals solicitud.UsuarioID
                                   join solicitudAuditoria in _dataBaseService.SolicitudAuditorias
                                   on solicitud.SolicitudID equals solicitudAuditoria.SolicitudID
                                   join usuarioElimina in _dataBaseService.Usuarios
                                   on solicitudAuditoria.UsuarioEliminaID equals usuarioElimina.UsuarioID
                             select new ListarSolicitudesEliminadasResponse
                                   { 
                                        PublicSolicitudID = solicitud.PublicID,
                                        PublicUsuarioSolicitanteID = usuarioSolicitante.PublicID,
                                        PublicUsuarioEliminacionID = usuarioElimina.PublicID,
                                        DetalleSolicitud = solicitud.DetalleSolicitud,
                                        MotivoEliminacion = solicitudAuditoria.MotivoEliminacion,
                                        DeletedAt = solicitudAuditoria.DeletedAt
                                   }).AsQueryable();

            var totalRecords = await queryBase.CountAsync();

            var paginadoQuery = queryBase
                .OrderByDescending(s => s.DeletedAt)
                .Skip((paginacionParams.PageNumber - 1) * paginacionParams.PageSize)
                .Take(paginacionParams.PageSize);

            var resultado = await paginadoQuery.ToListAsync();

            return new PaginadoResponse<ListarSolicitudesEliminadasResponse>(
                resultado,
                paginacionParams.PageNumber,
                paginacionParams.PageSize,
                totalRecords
            );

        }
    }
}
