using Caja.Servicios.Application.DataBase.Auth.Queries.ObtenerUsuarioPorEmail;
using Caja.Servicios.Application.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caja.Servicios.Api.Controllers.Usuario
{
    [Route("api/v1/usuarios")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ObtenerUsuarioPorEmailController : ControllerBase
    {
        private readonly IObtenerUsuarioPorEmailQuery _obtenerUsuarioPorEmailQuery;
        public ObtenerUsuarioPorEmailController(IObtenerUsuarioPorEmailQuery obtenerUsuarioPorEmailQuery)
        {
            _obtenerUsuarioPorEmailQuery = obtenerUsuarioPorEmailQuery;
        }

        [Tags("Usuarios")]
        [Authorize]
        [HttpGet("obtener-usuario-por-email")]
        public async Task<IActionResult> ObtenerUsuario(
            [FromQuery] string email)
        {
            var data = await _obtenerUsuarioPorEmailQuery.ExecuteAsync(email);
            return StatusCode(StatusCodes.Status200OK, data);
        }
    }
}
