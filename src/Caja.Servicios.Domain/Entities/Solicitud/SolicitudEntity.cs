
using Caja.Servicios.Domain.Entities.SolicitudAutitoria;
using Caja.Servicios.Domain.Entities.Usuario;

namespace Caja.Servicios.Domain.Entities.Solicitud
{
    public class SolicitudEntity
    {
        public int SolicitudID { get; set; }
        public Guid PublicID { get; set; }
        public int UsuarioID { get; set; }
        public string DetalleSolicitud { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public UsuarioEntity UsuarioReference { get; set; }
        public SolicitudAuditoriaEntity? AuditoriaReference { get; set; }
    }
}
