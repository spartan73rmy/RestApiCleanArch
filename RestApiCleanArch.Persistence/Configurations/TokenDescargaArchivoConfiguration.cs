using RestApiCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestApiCleanArch.Persistence.Configurations
{
    public class TokenDescargaArchivoConfiguration : IEntityTypeConfiguration<TokenDescargaArchivo>
    {
        public void Configure(EntityTypeBuilder<TokenDescargaArchivo> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.HashArchivo);

            builder.Property(el => el.HashArchivo).IsRequired();
            builder.Property(el => el.Token).IsRequired();
        }
    }
}
