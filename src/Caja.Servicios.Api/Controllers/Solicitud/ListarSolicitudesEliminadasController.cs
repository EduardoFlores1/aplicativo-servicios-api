using Caja.Servicios.Application.DataBase.Solicitud.Queries.ListarSolicitudesEliminadas;
using Caja.Servicios.Domain.Models.Paginacion;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Solicitud
{
    [Route("api/v1/solicitudes")]
    [ApiController]
    public class ListarSolicitudesEliminadasController : ControllerBase
    {
        private readonly IListarSolicitudesEliminadasQuery listarSolicitudesEliminadasQuery;
        public ListarSolicitudesEliminadasController(IListarSolicitudesEliminadasQuery listarSolicitudesEliminadasQuery)
        {
            this.listarSolicitudesEliminadasQuery = listarSolicitudesEliminadasQuery;
        }

        [HttpGet("eliminadas")]
        public async Task<ActionResult<PaginadoResponse<ListarSolicitudesEliminadasResponse>>> ListarEliminadas(
            [FromQuery] PaginacionParams paginacionParams) { 
            
            var data = await listarSolicitudesEliminadasQuery.ExecuteAsync(paginacionParams);

            return StatusCode(StatusCodes.Status200OK, data);


        }
    }
}
