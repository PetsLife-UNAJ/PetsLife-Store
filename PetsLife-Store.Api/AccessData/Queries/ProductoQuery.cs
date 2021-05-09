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

        public ResponseGetProductoById GetProductoById(int id)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var producto = db.Query("Productos").Select(
                "ProductoId", "Nombre", "Categoria", "Imagen"
                , "CantidadStock","Precio"
                ).Where("ProductoId", "=", id);
            var query = producto.Get<ResponseGetProductoById>();

            return query.FirstOrDefault();
        }

        public List<ResponseGetAllProductos> GetProductos()
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var producto = db.Query("Productos").Select(
                "Nombre", "Categoria", "Imagen"
                , "CantidadStock", "Precio", "ProductoId"
                );
            var query = producto.Get<ResponseGetAllProductos>();
            return query.ToList();
        }
    }
}
