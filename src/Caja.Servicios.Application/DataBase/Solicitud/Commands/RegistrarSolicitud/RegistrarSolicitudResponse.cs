namespace Caja.Servicios.Application.DataBase.Solicitud.Commands.RegistrarSolicitud
{
    public class RegistrarSolicitudResponse
    {
        public Guid PublicUsuarioID { get; set; }
        public string DetalleSolicitud { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
