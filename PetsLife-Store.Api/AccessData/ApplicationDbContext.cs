using AccessData.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccessData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Comprador> Compradores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProductoPedido> ProductosPedidos { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CarritoConfiguration()          .Configure(modelBuilder.Entity<Carrito>());
            new CompradorConfiguration()        .Configure(modelBuilder.Entity<Comprador>());
            new ProductoConfiguration()         .Configure(modelBuilder.Entity<Producto>());
            new ProductoPedidoConfiguration()   .Configure(modelBuilder.Entity<ProductoPedido>());
            new TiendaConfiguration()           .Configure(modelBuilder.Entity<Tienda>());
            new CategoriaConfiguration()        .Configure(modelBuilder.Entity<Categoria>());
        }

    }
}
