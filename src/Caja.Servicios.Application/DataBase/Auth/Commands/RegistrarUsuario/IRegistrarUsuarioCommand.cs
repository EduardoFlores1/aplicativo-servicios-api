namespace Caja.Servicios.Application.DataBase.Auth.Commands.RegistrarUsuario
{
    public interface IRegistrarUsuarioCommand
    {
        Task<RegistrarUsuarioResponse> ExecuteAsync(RegistrarUsuarioRequest request);
    }
}
