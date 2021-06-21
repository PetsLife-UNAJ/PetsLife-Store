using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessData.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(50);

            builder.HasData(new Categoria[]
            {
                new()
                {
                    CategoriaId = 1,
                    Descripcion = "Farmacia"
                },
                new()
                {
                    CategoriaId = 2,
                    Descripcion = "Alimento"
                },
                new()
                {
                    CategoriaId = 3,
                    Descripcion = "Accesorio"
                }
            });
        }

       
    }
}
