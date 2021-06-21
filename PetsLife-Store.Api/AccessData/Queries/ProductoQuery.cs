using Domain.DTOs;
using Domain.Interfaces.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AccessData.Queries
{
    public class ProductoQuery : IProductoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKatacompiler;


        public ProductoQuery(IDbConnection connection, Compiler sqlKatacompiler)
        {
            this.connection = connection;
            this.sqlKatacompiler = sqlKatacompiler;
        }

        public GetProductoDTO GetProductoById(int id)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            GetProductoDTO producto = db.Query("Productos")
                .Select("Productos.ProductoId",
                "Productos.Nombre",
                "Categorias.Descripcion AS Categoria",
                "Productos.Imagen",
                "Productos.Descripcion",
                "Productos.Rating",
                "Productos.CantidadStock",
                "Productos.Precio",
                "Productos.TiendaId"
                )
                .Join("Categorias", "Categorias.CategoriaId", "Productos.CategoriaId")
                .Where("ProductoId", id).Get<GetProductoDTO>().FirstOrDefault();
            
            return producto;
        }

        public List<GetProductoDTO> GetProductos(string categoria)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            List<GetProductoDTO> productos = db.Query("Productos")
                .Select("Productos.ProductoId",
                "Productos.Nombre",
                "Categorias.Descripcion AS Categoria",
                "Productos.Imagen",
                "Productos.Descripcion",
                "Productos.Rating",
                "Productos.CantidadStock",
                "Productos.Precio",
                "Productos.TiendaId"
                )
                .Join("Categorias", "Categorias.CategoriaId", "Productos.CategoriaId")
                .When(!string.IsNullOrWhiteSpace(categoria), q => q.WhereLike("Categorias.Descripcion", $"%{categoria}%"))
                .Get<GetProductoDTO>().ToList();
            return productos;
        }
    }
}
