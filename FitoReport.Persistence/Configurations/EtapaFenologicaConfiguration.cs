using FitoReport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitoReport.Persistence.Configurations
{
    public class EtapaFenologicaConfiguration : IEntityTypeConfiguration<EtapaFenologica>
    {
        public void Configure(EntityTypeBuilder<EtapaFenologica> builder)
        {
            {
                builder.HasKey(el => el.Id);

                builder.HasIndex(el => el.IdReport);

                builder.Property(el => el.Nombre)
                .IsRequired()
                .IsUnicode(true);
            }
        }
    }
}