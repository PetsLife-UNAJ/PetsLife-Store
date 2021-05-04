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
            builder.Property(e => e.TiendaId).HasDefaultValue(1);

            builder.HasData(new Producto[]
            {
                new() {Nombre = "Pipeta", CantidadStock = 4, Categoria = "Farmacia", Imagen = "imagen.png", Precio = 2549, ProductoId = 1, TiendaId = 1},
                new() {Nombre = "Dow Chow 20 kg", CantidadStock = 1, Categoria = "Alimento", Imagen = "dogchow.png", Precio = 6931, ProductoId = 2, TiendaId = 1},
                new() {Nombre = "Cat Chow 15 kg", CantidadStock = 77, Categoria = "Alimento", Imagen = "catchow.png", Precio = 2350, ProductoId = 3, TiendaId = 1},
                new() {Nombre = "Collar anti pulgas", CantidadStock = 12, Categoria = "Accesorios", Imagen = "antipulgas.png", Precio = 350, ProductoId = 4, TiendaId = 1},
                new() {Nombre = "Torre gatos 2 metros", CantidadStock = 32, Categoria = "Accesorios", Imagen = "torregatos.png", Precio = 23500, ProductoId = 5, TiendaId = 1}
            });

        }
    }
}
