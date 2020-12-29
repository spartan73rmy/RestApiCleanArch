using RestApiCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestApiCleanArch.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(el => el.Id);
            builder.HasIndex(el => el.NombreUsuario).IsUnique();
            builder.HasIndex(el => el.Email).IsUnique();

            builder.Property(el => el.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(el => el.NombreUsuario)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(el => el.TokenConfirmacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(el => el.HashedPassword)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(el => el.Confirmado)
                .IsRequired()
                .IsUnicode();

            builder.Property(el => el.FechaRegistro);

            builder.Property(el => el.ApellidoMaterno)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(el => el.ApellidoPaterno)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(el => el.ImagenPerfil)
                .IsUnicode(false);

            builder.Property(el => el.Nombre)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(el => el.AccessFailedCount)
                .IsRequired();

            builder.Property(el => el.LockoutEnd)
                .IsRequired();

            builder.Property(el => el.NormalizedUserName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(el => el.NormalizedEmail)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);
        }
    }
}
