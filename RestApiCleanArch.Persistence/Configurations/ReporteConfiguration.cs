using RestApiCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestApiCleanArch.Persistence.Configurations
{
    class ReporteConfiguration : IEntityTypeConfiguration<Reporte>
    {
        public void Configure(EntityTypeBuilder<Reporte> builder)
        {
            builder.HasKey(el => el.Id);

            builder.Property(el => el.Latitude)
                .IsRequired();

            builder.Property(el => el.Longitud)
                .IsRequired();

            builder.Property(el => el.Cultivo)
                .IsRequired();

            builder.Property(el => el.Lugar)
                .IsRequired()
                .IsUnicode(true);

            builder.Property(el => el.Observaciones)
                .IsRequired()
                .IsUnicode(true);

            builder.Property(el => el.Predio)
                .IsRequired()
                .IsUnicode(true);

            builder.Property(el => el.Productor)
                .IsRequired()
                .IsUnicode(true);

            builder.Property(el => el.Ubicacion)
                .IsRequired()
                .IsUnicode(true);

        }

    }
}
