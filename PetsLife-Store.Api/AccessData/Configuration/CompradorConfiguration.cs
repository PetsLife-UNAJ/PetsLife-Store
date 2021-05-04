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
            builder.HasIndex(e => e.CompradorId);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(16);
            builder.Property(e => e.Email).IsRequired();

            #region Carga de compradores con su carrito por defecto para testeo database.

            Comprador comprador1 = new()
            {
                CompradorId = 1,
                Email = "juancho@gmail.com",
                Nombre = "Juan"
                //CarritoId = 1
            };


            Comprador comprador2 = new()
            {
                CompradorId = 2,
                Email = "lucho@gmail.com",
                Nombre = "Luis"
                //CarritoId = 2
            };


            Comprador comprador3 = new()
            {
                CompradorId = 3,
                Email = "seba@gmail.com",
                Nombre = "Sebastian"
                //CarritoId = 3
            };

            builder.HasData(comprador1);
            builder.HasData(comprador2);
            builder.HasData(comprador3);

            #endregion
        }

    }
}
