using RestApiCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestApiCleanArch.Persistence.Configurations
{
    public class ArchivoConfiguration : IEntityTypeConfiguration<Archivo>
    {
        public void Configure(EntityTypeBuilder<Archivo> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdUsuario);

            builder.HasIndex(el => el.IdReporte);

            builder.Property(el => el.Hash).IsRequired();
            builder.Property(el => el.ContentType).IsRequired();
            builder.Property(el => el.Nombre).IsRequired();

            builder.HasOne(el => el.IdUsuarioNavigation)
                .WithMany(el => el.ArchivoUsuario)
                .HasForeignKey(el => el.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArchivoUsuario_Usuario");

            builder.HasOne(el => el.IdReporteNavigation)
                .WithMany(el => el.Archivos)
                .HasForeignKey(el => el.IdReporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArchivoUsuario_Reporte");
        }
    }
}
