using FitoReport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitoReport.Persistence.Configurations
{
    public class PlagaConfiguration : IEntityTypeConfiguration<Plaga>
    {
        public void Configure(EntityTypeBuilder<Plaga> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdReport);

            builder.Property(el => el.Nombre)
            .IsRequired()
            .IsUnicode(true);
        }
    }
}
