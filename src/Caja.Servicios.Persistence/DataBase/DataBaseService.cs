using Caja.Servicios.Application.DataBase;
using Caja.Servicios.Domain.Entities.Solicitud;
using Caja.Servicios.Domain.Entities.SolicitudAutitoria;
using Caja.Servicios.Domain.Entities.Usuario;
using Caja.Servicios.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Caja.Servicios.Persistence.DataBase
{
    public class DataBaseService: DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<SolicitudEntity> Solicitudes { get; set; }
        public DbSet<SolicitudAuditoriaEntity> SolicitudAuditorias { get; set; }

        public async Task<bool> SaveAsync() {
            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder) { 
            new UsuarioConfiguration(modelBuilder.Entity<UsuarioEntity>());
            new SolicitudConfiguration(modelBuilder.Entity<SolicitudEntity>());
            new SolicitudAuditoriaConfiguration(modelBuilder.Entity<SolicitudAuditoriaEntity>());
        }
    }
}
