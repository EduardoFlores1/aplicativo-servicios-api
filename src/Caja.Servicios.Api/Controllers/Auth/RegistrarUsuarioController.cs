using Caja.Servicios.Application.DataBase.Auth.Commands.RegistrarUsuario;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Auth
{
    [Route("api/v1/auth")]
    [ApiController]
    public class RegistrarUsuarioController : ControllerBase
    {
        private readonly IRegistrarUsuarioCommand _registrarUsuarioCommand;

        public RegistrarUsuarioController(IRegistrarUsuarioCommand registrarUsuarioCommand)
        {
            _registrarUsuarioCommand = registrarUsuarioCommand;
        }

        [HttpPost("registrar-usuario")]
        public async Task<IActionResult> RegistrarUsuario(
            [FromBody] RegistrarUsuarioRequest request) {
            
            var data = await _registrarUsuarioCommand.ExecuteAsync(request);

            return StatusCode(StatusCodes.Status201Created, data);
        }
    }
}
