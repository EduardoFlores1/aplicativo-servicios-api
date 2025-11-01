using Caja.Servicios.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caja.Servicios.Persistence.Configuration
{
    public class UsuarioConfiguration
    {
        public UsuarioConfiguration(EntityTypeBuilder<UsuarioEntity> entityBuilder)
        {
            entityBuilder.ToTable("Usuarios");
            entityBuilder.HasKey(u => u.UsuarioID);
            entityBuilder.Property(u => u.PublicID).IsRequired();
            entityBuilder.Property(u => u.Nombres).IsRequired().HasMaxLength(50);
            entityBuilder.Property(u => u.Email).IsRequired().HasMaxLength(255);
            entityBuilder.HasIndex(u => u.Email).IsUnique();
            entityBuilder.Property(u => u.Password).IsRequired().HasMaxLength(512);

            entityBuilder.HasMany(u => u.SolicitudesReference)
                .WithOne(s => s.UsuarioReference)
                .HasForeignKey(s => s.UsuarioID);

            entityBuilder.HasMany(u => u.AuditoriasReference)
                .WithOne(sa => sa.UsuarioReference)
                .HasForeignKey(sa => sa.UsuarioEliminaID);
        }
    }
}
