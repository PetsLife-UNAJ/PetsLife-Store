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
