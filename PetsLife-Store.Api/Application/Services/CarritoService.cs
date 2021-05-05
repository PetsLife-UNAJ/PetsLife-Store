using AccessData.Commands.Repository;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{   
    public class CarritoService  : ICarritoService
    {
        private readonly IGenericsRepository _repository;
        private readonly ICarritoQuery _query;
        private readonly IProductoService _productoService;

        public CarritoService(IGenericsRepository repository, ICarritoQuery query, IProductoService productoService)
        {
            _repository = repository;
            _query = query;
            _productoService = productoService;
        }

        // cambiar, el precio total se obtiene con la lista de todos los productos del carrito
        public int CalcularPrecioTotal(ResponseGetProductoById producto , ResponseGetCarritoById carrito)
        {
            int total = carrito.PrecioTotal;
            total += producto.Precio;
            return total;
        }

        public GenericsCreatedResponseDto AddProductoPedido(int idproducto, int idcarrito)
        {
            ProductoPedido productoPedido = new()
            {
                ProductoId = idproducto,
                CarritoId = idcarrito,
                Cantidad = 1
            };
            _repository.Add(productoPedido);

            ResponseGetCarritoById carritoById = GetCarritoById(idcarrito);
            int compradorId = carritoById.Comprador.CompradorId;

            ResponseGetProductoById producto = _productoService.GetProductoById(idproducto);
            int preciototal = CalcularPrecioTotal(producto , carritoById);

            ActualizarCarrito(idcarrito, preciototal, compradorId);

            return new GenericsCreatedResponseDto { Entity = "ProductoPedido", Id = productoPedido.ProductoPedidoId.ToString() };
        }

        private void ActualizarCarrito(int carritoId , int precio , int idComprador)
        {
            Carrito carrito = _repository.Exists<Carrito>(carritoId);
            carrito.CarritoId = carritoId;
            carrito.PrecioTotal = precio;
            carrito.CompradorId = idComprador;

            _repository.Update<Carrito>(carrito);
        }

        public void RemoveProductoPedidoFromCarrito(int idProductoPedido)
        {
            ProductoPedido pp = _query.GetProductoPedidoById(idProductoPedido);
            _repository.Delete(pp);
        }

        public ResponseGetCarritoById GetCarritoById(int idCarrito)
        {
            return _query.GetCarritoById(idCarrito);
        }
    }
}
