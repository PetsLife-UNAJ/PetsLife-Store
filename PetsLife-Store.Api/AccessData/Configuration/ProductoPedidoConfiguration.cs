using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

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
