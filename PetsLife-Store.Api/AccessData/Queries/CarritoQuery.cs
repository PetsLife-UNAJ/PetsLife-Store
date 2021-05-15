using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AccessData.Queries
{
    public class CarritoQuery : ICarritoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKatacompiler;
        private readonly IProductoQuery _producto_query;
        private readonly IProductoService _productoService;


        public CarritoQuery(IDbConnection connection, Compiler sqlKatacompiler, IProductoQuery producto_query, IProductoService productoService)
        {
            this.connection = connection;
            this.sqlKatacompiler = sqlKatacompiler;
            _producto_query = producto_query;
            _productoService = productoService;
        }

        public ProductoPedido GetProductoPedidoById(int productoPedidoId)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);

            ProductoPedido productoPedido = db.Query("ProductosPedidos").Where("ProductoPedidoId", productoPedidoId).FirstOrDefault<ProductoPedido>();

            return productoPedido;
        }


        public GetCarritoDTO GetCarritoById(int carritoId)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);

            var carrito = db.Query("Carritos")
                .Select("CarritoId", "PrecioTotal", "CompradorId")
                .Where("CarritoId", "=", carritoId)
                .FirstOrDefault<AddCarritoDTO>();

            // falla si carrito es null.
            var comprador = db.Query("Compradores")
                .Select("CompradorId", "Nombre", "Email")
                .Where("CompradorId", "=", carrito.CompradorId)
                .FirstOrDefault<GetCompradorDTO>();

            // falla si carrito es null.
            var idsProductos = db.Query("ProductosPedidos")
                .Select("ProductoId", "ProductoPedidoId")
                .Where("CarritoId", "=", carritoId)
                .Get<int>().ToList();

            List<GetProductoDTO> listaProductos = new();
            foreach (var item in idsProductos)
            {
                GetProductoDTO producto = _productoService.GetProductoById(item);
                listaProductos.Add(producto);
            }

            return new GetCarritoDTO
            {
                CarritoId = carrito.CarritoId,
                PrecioTotal = carrito.PrecioTotal,
                Comprador = comprador,
                ProductoPedidos = listaProductos 
            };

        }
    }
}
