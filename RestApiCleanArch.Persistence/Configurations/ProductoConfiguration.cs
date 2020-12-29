using RestApiCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestApiCleanArch.Persistence.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdReport);

            builder.Property(el => el.NombreProducto)
             .IsRequired()
             .IsUnicode(true);

            builder.Property(el => el.Unidad)
             .IsRequired()
             .IsUnicode(true);

            builder.Property(el => el.Cantidad)
             .IsRequired();

            builder.Property(el => el.Concentracion)
            .IsRequired()
            .IsUnicode(true);

            builder.Property(el => el.IngredienteActivo)
            .IsRequired()
            .IsUnicode(true);

            builder.Property(el => el.IntervaloSeguridad)
            .IsRequired()
            .IsUnicode(true);

            builder.HasOne(el => el.Reporte)
              .WithMany(el => el.Productos)
              .HasForeignKey(el => el.IdReport)
              .OnDelete(DeleteBehavior.Cascade)
              .HasConstraintName("FK_Productos_Reporte");
        }
    }
}
