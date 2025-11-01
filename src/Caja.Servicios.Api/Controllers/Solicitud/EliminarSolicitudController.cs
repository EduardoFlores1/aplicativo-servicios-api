using Caja.Servicios.Application.DataBase.Solicitud.Commands.EliminarSolicitud;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Solicitud
{
    [Route("api/v1/solicitudes")]
    [ApiController]
    public class EliminarSolicitudController : ControllerBase
    {
        private readonly IEliminarSolicitudCommand _eliminarSolicitudCommand;
        public EliminarSolicitudController(IEliminarSolicitudCommand eliminarSolicitudCommand)
        {
            _eliminarSolicitudCommand = eliminarSolicitudCommand;   
        }

        [HttpDelete("eliminar-solicitud")]
        public async Task<IActionResult> EliminarSolicitud(
            [FromBody] EliminarSolicitudRequest request) { 
            
            await _eliminarSolicitudCommand.ExecuteAsync(request);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
