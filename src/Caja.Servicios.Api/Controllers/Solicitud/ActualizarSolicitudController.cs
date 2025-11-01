using Caja.Servicios.Application.DataBase.Solicitud.Commands.ActualizarSolicitud;
using Caja.Servicios.Application.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Solicitud
{
    
    [Route("api/v1/solicitudes")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ActualizarSolicitudController : ControllerBase
    {
        private readonly IActualizarSolicitudCommand _actualizarSolicitudCommand;
        public ActualizarSolicitudController(IActualizarSolicitudCommand actualizarSolicitudCommand)
        {
            _actualizarSolicitudCommand = actualizarSolicitudCommand;
        }

        [Tags("Solicitudes")]
        [Authorize]
        [HttpPatch("actualizar-solicitud")]
        public async Task<IActionResult> ActualizarSolicitud(
            [FromBody] ActualizarSolicitudRequest request) { 
            
            var data = await _actualizarSolicitudCommand.ExecuteAsync(request);

            return StatusCode(StatusCodes.Status200OK, data);
        }
    }
}
