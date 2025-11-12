using Caja.Servicios.Application.DataBase.Solicitud.Queries.ListarSolicitudesEliminadas;
using Caja.Servicios.Application.Exception;
using Caja.Servicios.Application.Features.BaseResponse;
using Caja.Servicios.Domain.Models.Paginacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Solicitud
{
    
    [Route("api/v1/solicitudes")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ListarSolicitudesEliminadasController : ControllerBase
    {
        private readonly IListarSolicitudesEliminadasQuery listarSolicitudesEliminadasQuery;
        public ListarSolicitudesEliminadasController(IListarSolicitudesEliminadasQuery listarSolicitudesEliminadasQuery)
        {
            this.listarSolicitudesEliminadasQuery = listarSolicitudesEliminadasQuery;
        }

        [Tags("Solicitudes")]
        [Authorize]
        [HttpGet("eliminadas")]
        public async Task<IActionResult> ListarEliminadas(
            [FromQuery] PaginacionParams paginacionParams) { 
            
            var data = await listarSolicitudesEliminadasQuery.ExecuteAsync(paginacionParams);

            return StatusCode(StatusCodes.Status200OK,
                    BaseResponseApi.Ok<PaginadoResponse<ListarSolicitudesEliminadasResponse>>(StatusCodes.Status200OK, data)
                );


        }
    }
}
