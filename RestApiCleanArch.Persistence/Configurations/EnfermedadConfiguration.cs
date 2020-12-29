using RestApiCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestApiCleanArch.Persistence.Configurations
{
    public class EnfermedadConfiguration : IEntityTypeConfiguration<Enfermedad>
    {
        public void Configure(EntityTypeBuilder<Enfermedad> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdReport);

            builder.Property(el => el.Nombre)
            .IsRequired()
            .IsUnicode(true);
        }
    }
}
