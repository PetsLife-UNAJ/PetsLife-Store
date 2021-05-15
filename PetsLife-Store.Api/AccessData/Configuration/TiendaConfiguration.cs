using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessData.Configuration
{
    public class TiendaConfiguration : IEntityTypeConfiguration<Tienda>
    {

        public void Configure(EntityTypeBuilder<Tienda> builder)
        {
            builder.HasIndex(e => e.TiendaId);

            // Por defecto habra una unica tienda en toda la aplicacion
            Tienda tienda = new()
            {
                TiendaId = 1,
                Nombre = "Pet Store"
            };

            builder.HasData(tienda);

        }
    }
}
