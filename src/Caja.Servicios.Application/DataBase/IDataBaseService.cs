using Caja.Servicios.Domain.Entities.Solicitud;
using Caja.Servicios.Domain.Entities.SolicitudAutitoria;
using Caja.Servicios.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Caja.Servicios.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<UsuarioEntity> Usuarios { get; set; }
        DbSet<SolicitudEntity> Solicitudes { get; set; }
        DbSet<SolicitudAuditoriaEntity> SolicitudAuditorias { get; set; }
        Task<bool> SaveAsync();
    }
}
