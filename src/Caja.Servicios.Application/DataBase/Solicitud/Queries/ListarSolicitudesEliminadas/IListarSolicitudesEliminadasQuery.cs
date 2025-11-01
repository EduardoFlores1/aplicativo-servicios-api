using Caja.Servicios.Domain.Models.Paginacion;

namespace Caja.Servicios.Application.DataBase.Solicitud.Queries.ListarSolicitudesEliminadas
{
    public interface IListarSolicitudesEliminadasQuery
    {
        Task<PaginadoResponse<ListarSolicitudesEliminadasResponse>> ExecuteAsync(PaginacionParams paginacionParams);
    }
}
