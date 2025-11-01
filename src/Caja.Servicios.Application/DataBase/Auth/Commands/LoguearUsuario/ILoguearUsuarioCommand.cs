namespace Caja.Servicios.Application.DataBase.Auth.Commands.LoguearUsuario
{
    public interface ILoguearUsuarioCommand
    {
        Task<LoguearUsuarioResponse> ExecuteAsync(LoguearUsuarioRequest request);
    }
}
