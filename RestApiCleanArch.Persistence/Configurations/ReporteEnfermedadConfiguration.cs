using RestApiCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestApiCleanArch.Persistence.Configurations
{
    public class ReporteEnfermedadConfiguration : IEntityTypeConfiguration<ReporteEnfermedad>
    {
        public void Configure(EntityTypeBuilder<ReporteEnfermedad> builder)
        {
            builder.HasKey(el => el.Id);
            builder.HasIndex(el => el.IdReporte);
            builder.HasIndex(el => el.IdEnfermedad);

            //builder.HasKey(c => new { c.IdReporte, c.IdEnfermedad});

            builder.HasOne(el => el.Reporte)
                .WithMany(el => el.ReporteEnfermedad)
                .HasForeignKey(el => el.IdReporte);

            builder.HasOne(el => el.Enfermedad)
                .WithMany(el => el.ReporteEnfermedad)
                .HasForeignKey(el => el.IdEnfermedad);

        }
    }
}
