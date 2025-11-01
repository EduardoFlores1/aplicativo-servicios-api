using Caja.Servicios.Application.DataBase.Auth.Commands.LoguearUsuario;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Auth
{
    [Route("api/v1/auth")]
    [ApiController]
    public class LoguearUsuarioController : ControllerBase
    {
        private readonly ILoguearUsuarioCommand _loguearUsuarioCommand;
        public LoguearUsuarioController(ILoguearUsuarioCommand loguearUsuarioCommand)
        {
            _loguearUsuarioCommand = loguearUsuarioCommand;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoguearUsuario(
            [FromBody] LoguearUsuarioRequest request)
        {
            var response = await _loguearUsuarioCommand.ExecuteAsync(request);
            if (response == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Credenciales inválidas.");
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
