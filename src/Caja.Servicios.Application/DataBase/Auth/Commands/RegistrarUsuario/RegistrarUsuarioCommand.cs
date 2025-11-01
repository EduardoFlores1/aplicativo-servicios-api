using Caja.Servicios.Domain.Entities.Usuario;

namespace Caja.Servicios.Application.DataBase.Auth.Commands.RegistrarUsuario
{
    public class RegistrarUsuarioCommand: IRegistrarUsuarioCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public RegistrarUsuarioCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<RegistrarUsuarioResponse> ExecuteAsync(RegistrarUsuarioRequest request) {

            var nuevoUsuario = new UsuarioEntity
            {
                Nombres = request.Nombres,
                Email = request.Email,
                Password = request.Password
            };

            await _dataBaseService.Usuarios.AddAsync(nuevoUsuario);
            await _dataBaseService.SaveAsync();

            var response = new RegistrarUsuarioResponse
            {
                Nombres = nuevoUsuario.Nombres,
                Email = nuevoUsuario.Email
            };

            return response;
        }
    }
}
