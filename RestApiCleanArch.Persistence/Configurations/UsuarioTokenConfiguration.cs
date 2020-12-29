using RestApiCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestApiCleanArch.Persistence.Configurations
{
    internal class UsuarioTokenConfiguration : IEntityTypeConfiguration<UsuarioToken>
    {
        public void Configure(EntityTypeBuilder<UsuarioToken> builder)
        {
            builder.HasKey(el => el.Id);


            builder.HasIndex(el => el.IdUsuario);

            builder.HasIndex(el => el.RefreshToken).IsUnique(true);

            builder.Property(el => el.RefreshToken)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasOne(el => el.UsuarioNavigation)
                .WithMany(el => el.UsuarioTokens)
                .HasForeignKey(el => el.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioToken_Usuario");
        }
    }
}
