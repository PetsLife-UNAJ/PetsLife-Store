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
            builder.Property(e => e.CantidadStock).IsRequired();
            builder.Property(e => e.Imagen).IsRequired();
            builder.Property(e => e.TiendaId).HasDefaultValue(1);
            builder.Property(e => e.Rating).HasDefaultValue(10).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasMaxLength(1024).HasDefaultValue("");

            builder.HasOne(e => e.CategoriaNavigator).WithMany(c => c.ProductosNavigator).IsRequired();

            builder.HasData(new Producto[]
            {
                new() {Nombre = "Pipeta gatos", CantidadStock = 0, CategoriaId = 1, Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849714591042109510/unknown.png", Precio = 2549, ProductoId = 1, TiendaId = 1, Rating = 7,
                Descripcion = @"
                    Advantage® G es una solución antiparasitaria para uso externo, para el tratamiento y prevención de infestaciones por pulgas en gatos de hasta 4 Kg de peso.
                    Beneficios
                    Mata las pulgas dentro de las 24 horas
                    Previene las reinfestaciones durante un mes
                    De muy fácil aplicación"
                },

                new() {Nombre = "Dow Chow 20 kg - Carne", CantidadStock = 1, CategoriaId = 2, Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849734389634039848/unknown.png", Precio = 6931, ProductoId = 2, TiendaId = 1, Rating = 5,
                Descripcion = @"
                    PURINA DOG CHOW® Adultos Razas Pequeñas está específicamente formulado con los nutrientes e ingredientes de calidad que lo ayudarán a tener salud y vitalidad por muchos más años. Este producto le ofrece a tu perro adulto un alto aporte de energía y una partícula pequeña para adecuarse al tamaño de la mordida.
                    "
                },

                new() {Nombre = "Cat Chow 20 kg - Pescado", CantidadStock = 77, CategoriaId = 2, Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849734518260105246/unknown.png", Precio = 2350, ProductoId = 3, TiendaId = 1, Rating = 10,
                Descripcion = @"
                    Ofrécele a tu gato una fórmula rica en vitaminas y antioxidantes con un equilibrio perfecto de proteínas, grasas y carbohidratos para dar una vida más saludable y feliz. CAT CHOW® Adultos ayuda a fortalecer el corazón y el sistema inmunológico de tu gato adulto. Edad de Consumo: De 1 a 7 años.
                    "
                },

                new() {Nombre = "Collar Anti Pulgas Y Garrapatas Ultrasónico Perros Y Gatos", CantidadStock = 12, CategoriaId = 3, Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849735109976522809/unknown.png", Precio = 350, ProductoId = 4, TiendaId = 1, Rating = 1,
                Descripcion = @"
                    Advantage® G es una solución antiparasitaria para uso externo, para el tratamiento y prevención de infestaciones por pulgas en gatos de hasta 4 Kg de peso.
                    Beneficios
                    Mata las pulgas dentro de las 24 horas
                    Previene las reinfestaciones durante un mes
                    De muy fácil aplicación"
                },

                new() {Nombre = "Rascador Para Gato Torre Felpa + Sisal", CantidadStock = 32, CategoriaId = 3, Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849735366385598474/unknown.png", Precio = 23500, ProductoId = 5, TiendaId = 1, Rating = 0,
                Descripcion = @"
                    Rascador Alessia, 50 X 50 X 160 cm con superficie forrada en felpa y postes recubiertos en sisal natural. 
                    3 pelotas de juguetes con varilla y cuerda, hamaca y soga de juguete que cuelga sobre la hamaca. 
                    Con cueva. Gris claro
                    "
                },

                new() {Nombre = "Cama circular para Gato - Marron oscuro", CantidadStock = 12, CategoriaId = 3, Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849843675315175475/unknown.png", Precio = 23500, ProductoId = 6, TiendaId = 1, Rating = 8,
                Descripcion = @"
                   Camita cucha Moisés para perros toy, gatos grandes, cobayos y conejos enanos. Viene con almohadón!!! Si la queres para cobayos o erizos, acláramelo para enviártela el talle correspondiente.

                    Integra la camita de tu mascota a la decoración de tu casa.

                    Super linda! Funcional y novedosa!

                    Colores: gris oscuro, gris claro, azul, marfil, naranja, rojo y verde pastel*** (Consultar color antes de comprar y aclararlo al hacer la compra por favor, porque sino no se que color enviárte!!!)
                    "
                },

                new() {Nombre = "Juguete Gato Cañita Varita Cascabel Raton Plumas Extensible", CantidadStock = 12, CategoriaId = 3, Imagen = "https://cdn.discordapp.com/attachments/790717330447138847/849735929639206912/unknown.png", Precio = 197, ProductoId = 7, TiendaId = 1, Rating = 9,
                Descripcion = @"
                    CAÑITA PARA GATO
                    *Con ratita, plumas y cascabel.
                    *Soga elástica de 70 cm.
                    TU GATO ESTARA MAS FELIZ QUE NUNCA
                    "
                },
            });

        }
    }
}
