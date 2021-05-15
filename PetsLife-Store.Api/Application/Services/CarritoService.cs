using AccessData.Commands.Repository;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Services;

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

        public int CalcularPrecioTotal(GetProductoDTO producto , GetCarritoDTO carrito)
        {
            int total = carrito.PrecioTotal;
            total += producto.Precio;
            return total;
        }

        public GetProductoPedidoDTO AddProductoPedido(AddProductoPedidoDTO pp)
        {
            ProductoPedido productoPedido = new()
            {
                ProductoId = pp.ProductoId,
                CarritoId = pp.CarritoId,
                Cantidad = 1
            };
            _repository.Add(productoPedido);

            GetCarritoDTO carritoById = GetCarritoById(pp.CarritoId);
            int compradorId = carritoById.Comprador.CompradorId;

            GetProductoDTO producto = _productoService.GetProductoById(pp.ProductoId);
            int preciototal = CalcularPrecioTotal(producto , carritoById);

            UpdateCarrito(pp.CarritoId, preciototal, compradorId);

            return new GetProductoPedidoDTO 
            { 
                Cantidad = productoPedido.Cantidad,
                CarritoId = productoPedido.CarritoId,
                ProductoId = productoPedido.ProductoId,
                ProductoPedidoId = productoPedido.ProductoPedidoId
            };
        }

        private void UpdateCarrito(int carritoId , int precio , int idComprador)
        {
            Carrito carrito = _repository.Exists<Carrito>(carritoId);
            carrito.CarritoId = carritoId;
            carrito.PrecioTotal = precio;
            carrito.CompradorId = idComprador;

            _repository.Update<Carrito>(carrito);
        }

        public bool RemoveProductoPedidoFromCarrito(int idProductoPedido)
        {
            ProductoPedido pp = _query.GetProductoPedidoById(idProductoPedido);
            if (pp == null) return false;

            _repository.Delete(pp);
            return true;
        }

        public GetCarritoDTO GetCarritoById(int idCarrito)
        {
            return _query.GetCarritoById(idCarrito);
        }
    }
}
