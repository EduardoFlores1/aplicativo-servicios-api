
using Caja.Servicios.Domain.Entities.Solicitud;
using Caja.Servicios.Domain.Entities.SolicitudAutitoria;

namespace Caja.Servicios.Domain.Entities.Usuario
{
    public class UsuarioEntity
    {
        public int UsuarioID { get; set; }
        public Guid PublicID { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<SolicitudEntity> SolicitudesReference { get; set; }
        public ICollection<SolicitudAuditoriaEntity> AuditoriasReference { get; set; }
    }
}
