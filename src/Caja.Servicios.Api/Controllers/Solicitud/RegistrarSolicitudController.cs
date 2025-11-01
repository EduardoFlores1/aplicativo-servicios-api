using Caja.Servicios.Application.DataBase.Solicitud.Commands.RegistrarSolicitud;
using Caja.Servicios.Application.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Solicitud
{
    
    [Route("api/v1/solicitudes")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class RegistrarSolicitudController : ControllerBase
    {
        private readonly IRegistrarSolicitudCommand _registrarSolicitudCommand;
        public RegistrarSolicitudController(IRegistrarSolicitudCommand registrarSolicitudCommand)
        {
            _registrarSolicitudCommand = registrarSolicitudCommand;
        }

        [Tags("Solicitudes")]
        [Authorize]
        [HttpPost("registrar-solicitud")]
        public async Task<IActionResult> RegistrarSolicitud(
            [FromBody] RegistrarSolicitudRequest request)
        {
            var data = await _registrarSolicitudCommand.ExecuteAsync(request);
            return StatusCode(StatusCodes.Status201Created, data);
        }
    }
}
