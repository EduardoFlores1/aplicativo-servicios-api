namespace Caja.Servicios.Application.DataBase.Solicitud.Commands.EliminarSolicitud
{
    public interface IEliminarSolicitudCommand
    {
        Task ExecuteAsync(EliminarSolicitudRequest request);
    }
}
