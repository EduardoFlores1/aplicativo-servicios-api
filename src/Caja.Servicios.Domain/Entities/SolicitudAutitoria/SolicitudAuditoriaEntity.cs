using Caja.Servicios.Domain.Entities.Solicitud;
using Caja.Servicios.Domain.Entities.Usuario;

namespace Caja.Servicios.Domain.Entities.SolicitudAutitoria
{
    public class SolicitudAuditoriaEntity
    {
        public int AuditoriaID { get; set; }
        public Guid PublicID { get; set; }
        public int SolicitudID { get; set; }
        public int UsuarioEliminaID { get; set; }
        public string MotivoEliminacion { get; set; }
        public DateTime DeletedAt { get; set; }
        public UsuarioEntity UsuarioReference { get; set; }
        public SolicitudEntity SolicitudReference { get; set; }
    }
}
