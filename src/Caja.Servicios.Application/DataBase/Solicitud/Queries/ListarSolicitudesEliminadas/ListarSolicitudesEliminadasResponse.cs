namespace Caja.Servicios.Application.DataBase.Solicitud.Queries.ListarSolicitudesEliminadas
{
    public class ListarSolicitudesEliminadasResponse
    {
        public Guid PublicSolicitudID { get; set; }
        public Guid PublicUsuarioSolicitanteID { get; set; }
        public Guid PublicUsuarioEliminaID { get; set; }
        public string DetalleSolicitud { get; set; }
        public string MotivoEliminacion { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
