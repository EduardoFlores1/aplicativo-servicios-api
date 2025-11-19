using Caja.Servicios.Application.Features.Jwt;
using Microsoft.EntityFrameworkCore;

namespace Caja.Servicios.Application.DataBase.Auth.Commands.LoguearUsuario
{
    public class LoguearUsuarioCommand: ILoguearUsuarioCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IJwtService _jwtService;
        public LoguearUsuarioCommand(
            IDataBaseService dataBaseService,
            IJwtService jwtService)
        {
            _dataBaseService = dataBaseService;
            _jwtService = jwtService;
        }

        public async Task<LoguearUsuarioResponse> ExecuteAsync(LoguearUsuarioRequest request) {

            var usuarioEntity = await _dataBaseService.Usuarios
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (usuarioEntity == null) return null;

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, usuarioEntity.Password);

            if (!isPasswordValid) return null;

            return new LoguearUsuarioResponse
            {
                Token = _jwtService.GenerarToken(usuarioEntity)
            };
        }
    }
}
