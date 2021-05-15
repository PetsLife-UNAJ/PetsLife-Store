using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessData.Configuration
{
    public class ProductoPedidoConfiguration : IEntityTypeConfiguration<ProductoPedido>
    {

        public void Configure(EntityTypeBuilder<ProductoPedido> builder)
        {
            builder.HasIndex(e => e.ProductoPedidoId);
            builder.Property(e => e.Cantidad).HasDefaultValue(1);
            builder.Property(e => e.ProductoId).IsRequired();

            builder.HasOne(e => e.Carrito).WithMany(c => c.ProductoPedidos).IsRequired();
        }

    }
}
