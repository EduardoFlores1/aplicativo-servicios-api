namespace Caja.Servicios.Application.DataBase.Solicitud.Commands.EliminarSolicitud
{
    public class EliminarSolicitudRequest
    {
        public Guid PublicSolicitudID { get; set; }
        public string MotivoEliminacion { get; set; }
    }
}
