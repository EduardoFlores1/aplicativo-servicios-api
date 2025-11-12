using Caja.Servicios.Application.DataBase.Auth.Commands.RegistrarUsuario;
using Caja.Servicios.Application.Exception;
using Caja.Servicios.Application.Features.BaseResponse;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Auth
{
    [Route("api/v1/auth")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class RegistrarUsuarioController : ControllerBase
    {
        private readonly IRegistrarUsuarioCommand _registrarUsuarioCommand;

        public RegistrarUsuarioController(IRegistrarUsuarioCommand registrarUsuarioCommand)
        {
            _registrarUsuarioCommand = registrarUsuarioCommand;
        }

        [Tags("Auth")]
        [HttpPost("registrar-usuario")]
        public async Task<IActionResult> RegistrarUsuario(
            [FromBody] RegistrarUsuarioRequest request,
            [FromServices] IValidator<RegistrarUsuarioRequest> validator
            ) {

            var validate = await validator.ValidateAsync(request);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    BaseResponseApi.Fail<string>(StatusCodes.Status400BadRequest, validate.Errors)
                    );
            }

            var data = await _registrarUsuarioCommand.ExecuteAsync(request);

            return StatusCode(StatusCodes.Status201Created, 
                    BaseResponseApi.Ok<RegistrarUsuarioResponse>(StatusCodes.Status201Created, data)
                );
        }
    }
}
