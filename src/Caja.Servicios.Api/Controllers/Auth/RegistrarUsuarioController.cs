using Caja.Servicios.Application.DataBase.Auth.Commands.RegistrarUsuario;
using Caja.Servicios.Application.Exception;
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
            [FromBody] RegistrarUsuarioRequest request) {
            
            var data = await _registrarUsuarioCommand.ExecuteAsync(request);

            return StatusCode(StatusCodes.Status201Created, data);
        }
    }
}
