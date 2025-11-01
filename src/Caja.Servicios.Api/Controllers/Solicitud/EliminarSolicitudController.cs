using Caja.Servicios.Application.DataBase.Solicitud.Commands.EliminarSolicitud;
using Caja.Servicios.Application.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Solicitud
{
    
    [Route("api/v1/solicitudes")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class EliminarSolicitudController : ControllerBase
    {
        private readonly IEliminarSolicitudCommand _eliminarSolicitudCommand;
        public EliminarSolicitudController(IEliminarSolicitudCommand eliminarSolicitudCommand)
        {
            _eliminarSolicitudCommand = eliminarSolicitudCommand;   
        }

        [Tags("Solicitudes")]
        [Authorize]
        [HttpDelete("eliminar-solicitud")]
        public async Task<IActionResult> EliminarSolicitud(
            [FromBody] EliminarSolicitudRequest request) { 
            
            await _eliminarSolicitudCommand.ExecuteAsync(request);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
