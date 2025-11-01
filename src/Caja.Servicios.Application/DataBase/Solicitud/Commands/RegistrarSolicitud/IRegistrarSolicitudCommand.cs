namespace Caja.Servicios.Application.DataBase.Solicitud.Commands.RegistrarSolicitud
{
    public interface IRegistrarSolicitudCommand
    {
        Task<RegistrarSolicitudResponse> ExecuteAsync(RegistrarSolicitudRequest request);
    }
}
