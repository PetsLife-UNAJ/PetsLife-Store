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
    public class CompradorConfiguration : IEntityTypeConfiguration<Comprador>
    {
        public void Configure(EntityTypeBuilder<Comprador> builder)
        {
            //builder.Property(e => e.Carrito).IsRequired();
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(16);

        }
    }
}
