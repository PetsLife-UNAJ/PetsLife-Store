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

        public ResponseGetCarritoById GetCarritoById(int carritoId)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);

            var carrito = db.Query("Carritos")
                .Select("CarritoId", "PrecioTotal", "CompradorId")
                .Where("CarritoId", "=", carritoId)
                .FirstOrDefault<CarritoDTO>();

            var comprador = db.Query("Compradores")
                .Select("CompradorId", "Nombre", "Email")
                .Where("CompradorId", "=", carrito.CompradorId)
                .FirstOrDefault<ResponseGetCarritoByIdComprador>();

            var idsProductos = db.Query("ProductosPedidos")
                .Select("ProductoId")
                .Where("CarritoId", "=", carritoId)
                .Get<int>().ToList();

            List<ResponseGetProductoById> listaProductos = new List<ResponseGetProductoById>();
            foreach (var item in idsProductos)
            {
                ResponseGetProductoById producto = _productoService.GetProductoById(item);
                listaProductos.Add(producto);
            }

            return new ResponseGetCarritoById
            {
                CarritoId = carrito.CarritoId,
                PrecioTotal = carrito.PrecioTotal,
                Comprador = comprador,
                ProductoPedidos = listaProductos
            };

        }
    }
}
