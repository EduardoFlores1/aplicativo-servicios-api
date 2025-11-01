using Caja.Servicios.Application.DataBase.Auth.Commands.LoguearUsuario;
using Caja.Servicios.Application.Exception;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Auth
{
    [Route("api/v1/auth")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class LoguearUsuarioController : ControllerBase
    {
        private readonly ILoguearUsuarioCommand _loguearUsuarioCommand;
        public LoguearUsuarioController(ILoguearUsuarioCommand loguearUsuarioCommand)
        {
            _loguearUsuarioCommand = loguearUsuarioCommand;
        }

        [Tags("Auth")]
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
