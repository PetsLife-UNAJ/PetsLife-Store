using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessData.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {

        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Precio).IsRequired();
            builder.Property(e => e.Categoria).IsRequired().HasMaxLength(40);
            builder.Property(e => e.CantidadStock).IsRequired();
            builder.Property(e => e.Imagen).IsRequired();

        }
    }
}
