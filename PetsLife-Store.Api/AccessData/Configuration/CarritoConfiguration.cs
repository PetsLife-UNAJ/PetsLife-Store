using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessData.Configuration
{
    public class CarritoConfiguration : IEntityTypeConfiguration<Carrito>
    {

        public void Configure(EntityTypeBuilder<Carrito> builder)
        {
            builder.HasIndex(e => e.CarritoId);
            builder.Property(e => e.PrecioTotal).HasDefaultValue(0);

            builder.HasData(new Carrito[]
            {
                new() { CarritoId = 1, CompradorId = 1 },
                new() { CarritoId = 2, CompradorId = 2 },
                new() { CarritoId = 3, CompradorId = 3 }
            });
        }

    }
}
