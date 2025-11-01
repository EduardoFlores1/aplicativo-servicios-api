using Caja.Servicios.Application.DataBase.Auth.Queries.ObtenerUsuarioPorEmail;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Auth
{
    [Route("api/v1/auth")]
    [ApiController]
    public class ObtenerUsuarioPorEmailController : ControllerBase
    {
        private readonly IObtenerUsuarioPorEmailQuery _obtenerUsuarioPorEmailQuery;
        public ObtenerUsuarioPorEmailController(IObtenerUsuarioPorEmailQuery obtenerUsuarioPorEmailQuery)
        {
            _obtenerUsuarioPorEmailQuery = obtenerUsuarioPorEmailQuery;
        }

        [HttpGet("obtener-usuario-por-email")]
        public async Task<IActionResult> ObtenerUsuario(
            [FromQuery] string email)
        {
            var data = await _obtenerUsuarioPorEmailQuery.ExecuteAsync(email);
            return StatusCode(StatusCodes.Status200OK, data);
        }
    }
}
