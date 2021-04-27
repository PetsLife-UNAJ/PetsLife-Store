using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessData.Configuration
{
    public class CarritoConfiguration : IEntityTypeConfiguration<Carrito>
    {

        public void Configure(EntityTypeBuilder<Carrito> builder)
        {
            // Precio total se calcula por lo que no lo coloco aca como required
            // builder.Property(e => e.Comprador).IsRequired();
            builder.Property(e => e.CompradorId).IsRequired();
        }

    }
}
