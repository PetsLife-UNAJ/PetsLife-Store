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
                new() {Nombre = "Pipeta gatos", CantidadStock = 4, Categoria = "Farmacia", Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849714591042109510/unknown.png", Precio = 2549, ProductoId = 1, TiendaId = 1},
                new() {Nombre = "Dow Chow 20 kg - Carne", CantidadStock = 1, Categoria = "Alimento", Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849734389634039848/unknown.png", Precio = 6931, ProductoId = 2, TiendaId = 1},
                new() {Nombre = "Cat Chow 20 kg - Pescado", CantidadStock = 77, Categoria = "Alimento", Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849734518260105246/unknown.png", Precio = 2350, ProductoId = 3, TiendaId = 1},
                new() {Nombre = "Collar Anti Pulgas Y Garrapatas Ultrasónico Perros Y Gatos", CantidadStock = 12, Categoria = "Accesorios", Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849735109976522809/unknown.png", Precio = 350, ProductoId = 4, TiendaId = 1},
                new() {Nombre = "Rascador Para Gato Torre Felpa + Sisal", CantidadStock = 32, Categoria = "Accesorios", Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849735366385598474/unknown.png", Precio = 23500, ProductoId = 5, TiendaId = 1},
                new() {Nombre = "Cama circular para Gato - Marron oscuro", CantidadStock = 12, Categoria = "Accesorios", Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849735627150589952/unknown.png", Precio = 23500, ProductoId = 6, TiendaId = 1},
                new() {Nombre = "Juguete Gato Cañita Varita Cascabel Raton Plumas Extensible", CantidadStock = 12, Categoria = "Accesorios", Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849735929639206912/unknown.png", Precio = 197, ProductoId = 7, TiendaId = 1}
            });

        }
    }
}
