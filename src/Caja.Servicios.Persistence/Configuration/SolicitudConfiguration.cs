using Caja.Servicios.Domain.Entities.Solicitud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caja.Servicios.Persistence.Configuration
{
    public class SolicitudConfiguration
    {
        public SolicitudConfiguration(EntityTypeBuilder<SolicitudEntity> entityBuilder)
        {
            entityBuilder.ToTable("Solicitudes");
            entityBuilder.HasKey(s => s.SolicitudID);

            entityBuilder.Property(s => s.PublicID).IsRequired().HasDefaultValueSql("NEWSEQUENTIALID()");
            entityBuilder.Property(s => s.PublicID).ValueGeneratedOnAdd();

            entityBuilder.Property(s => s.UsuarioID).IsRequired();
            entityBuilder.Property(s => s.DetalleSolicitud).IsRequired().HasMaxLength(255);
            entityBuilder.Property(s => s.CreatedAt).IsRequired();
            entityBuilder.Property(s => s.UpdatedAt).IsRequired();
            entityBuilder.Property(s => s.IsUpdated).IsRequired();
            entityBuilder.Property(s => s.IsDeleted).IsRequired();

            entityBuilder.HasOne(s => s.UsuarioReference)
                .WithMany(u => u.SolicitudesReference)
                .HasForeignKey(s => s.UsuarioID);

        }
    }
}
