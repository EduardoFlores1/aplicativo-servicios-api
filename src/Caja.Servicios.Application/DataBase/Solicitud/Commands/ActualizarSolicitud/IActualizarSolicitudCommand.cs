namespace Caja.Servicios.Application.DataBase.Solicitud.Commands.ActualizarSolicitud
{
    public interface IActualizarSolicitudCommand
    {
        Task<ActualizarSolicitudResponse> ExecuteAsync(ActualizarSolicitudRequest request);
    }
}
