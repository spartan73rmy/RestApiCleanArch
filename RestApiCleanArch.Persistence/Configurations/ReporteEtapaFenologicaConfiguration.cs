using RestApiCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiCleanArch.Persistence.Configurations
{
    public class ReporteEtapaFenologicaConfiguration : IEntityTypeConfiguration<ReporteEtapaFenologica>
    {
        public void Configure(EntityTypeBuilder<ReporteEtapaFenologica> builder)
        {
            builder.HasKey(el => el.Id);
            builder.HasIndex(el => el.IdReporte);
            builder.HasIndex(el => el.IdEtapaFenologica);

            //builder.HasKey(c => new { c.IdReporte, c.IdEtapaFenologica});

            builder.HasOne(el => el.Reporte)
                .WithMany(el => el.ReporteEtapaFenologica)
                .HasForeignKey(el => el.IdReporte);

            builder.HasOne(el => el.EtapaFenologica)
                .WithMany(el => el.ReporteEtapaFenologica)
                .HasForeignKey(el => el.IdEtapaFenologica);
        }
    }
}
