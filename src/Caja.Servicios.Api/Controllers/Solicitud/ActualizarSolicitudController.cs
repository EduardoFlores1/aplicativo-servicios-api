using Caja.Servicios.Application.DataBase.Solicitud.Commands.ActualizarSolicitud;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Solicitud
{
    
    [Route("api/v1/solicitudes")]
    [ApiController]
    public class ActualizarSolicitudController : ControllerBase
    {
        private readonly IActualizarSolicitudCommand _actualizarSolicitudCommand;
        public ActualizarSolicitudController(IActualizarSolicitudCommand actualizarSolicitudCommand)
        {
            _actualizarSolicitudCommand = actualizarSolicitudCommand;
        }

        [Authorize]
        [HttpPatch("actualizar-solicitud")]
        public async Task<IActionResult> ActualizarSolicitud(
            [FromBody] ActualizarSolicitudRequest request) { 
            
            var data = await _actualizarSolicitudCommand.ExecuteAsync(request);

            return StatusCode(StatusCodes.Status200OK, data);
        }
    }
}
