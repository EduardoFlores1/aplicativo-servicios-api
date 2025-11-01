using Caja.Servicios.Domain.Entities.SolicitudAutitoria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caja.Servicios.Persistence.Configuration
{
    public class SolicitudAuditoriaConfiguration
    {
        public SolicitudAuditoriaConfiguration(EntityTypeBuilder<SolicitudAuditoriaEntity> entityBuilder)
        {
            entityBuilder.ToTable("Solicitud_Auditoria");
            entityBuilder.HasKey(sa => sa.AuditoriaID);
            entityBuilder.Property(sa => sa.PublicID).IsRequired();
            entityBuilder.Property(sa => sa.SolicitudID).IsRequired();
            entityBuilder.HasIndex(sa => sa.SolicitudID).IsUnique();
            entityBuilder.Property(sa => sa.UsuarioEliminaID).IsRequired();
            entityBuilder.Property(sa => sa.MotivoEliminacion).IsRequired().HasMaxLength(255);
            entityBuilder.Property(sa => sa.DeletedAt).IsRequired();

            entityBuilder.HasOne(sa => sa.UsuarioReference)
                .WithMany(u => u.AuditoriasReference)
                .HasForeignKey(sa => sa.UsuarioEliminaID);

            entityBuilder.HasOne(sa => sa.SolicitudReference)
                .WithOne(s => s.AuditoriaReference)
                .HasForeignKey<SolicitudAuditoriaEntity>(sa => sa.SolicitudID);

        }
    }
}
