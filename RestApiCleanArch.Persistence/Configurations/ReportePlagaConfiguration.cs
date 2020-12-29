using RestApiCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestApiCleanArch.Persistence.Configurations
{
    public class ReportePlagaConfiguration : IEntityTypeConfiguration<ReportePlaga>
    {
        public void Configure(EntityTypeBuilder<ReportePlaga> builder)
        {
            builder.HasKey(el => el.Id);
            builder.HasIndex(el => el.IdReporte);
            builder.HasIndex(el => el.IdPlaga);

            //builder.HasKey(el => new { el.IdReporte, el.IdPlaga });

            builder.HasOne(el => el.Plaga)
                .WithMany(el => el.ReportPlaga)
                .HasForeignKey(el => el.IdPlaga);

            builder.HasOne(el => el.Reporte)
                .WithMany(el => el.ReportePlaga)
                .HasForeignKey(el => el.IdReporte);
        }

    }
}
