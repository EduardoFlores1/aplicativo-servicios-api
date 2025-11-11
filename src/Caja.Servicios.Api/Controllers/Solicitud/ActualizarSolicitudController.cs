using Caja.Servicios.Application.DataBase.Solicitud.Commands.ActualizarSolicitud;
using Caja.Servicios.Application.Exception;
using Caja.Servicios.Application.Features.BaseResponse;
using FluentValidation;
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
            [FromBody] ActualizarSolicitudRequest request,
            [FromServices] IValidator<ActualizarSolicitudRequest> validator
            ) {
            
            var validate = await validator.ValidateAsync(request);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    BaseResponseApi.Fail<string>(StatusCodes.Status400BadRequest, validate.Errors)
                );
            }

            var data = await _actualizarSolicitudCommand.ExecuteAsync(request);

            return StatusCode(StatusCodes.Status200OK,
                    BaseResponseApi.Ok<ActualizarSolicitudResponse>(StatusCodes.Status200OK, data)
                );
        }
    }
}
