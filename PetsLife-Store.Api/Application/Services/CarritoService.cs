using AccessData.Commands.Repository;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{   
    public interface ICarritoService
    {
        GenericsCreatedResponseDto CreateCarrito(CreateCarritoRequestDto carritoDto);
    }
    public class CarritoService : ICarritoService  
    {
        private readonly IGenericsRepository _repository;
        private readonly IProductoService _productoService;
        public CarritoService(IGenericsRepository repository, IProductoService productoService)
        {
            _repository = repository;
            _productoService = productoService;
        }

        public GenericsCreatedResponseDto CreateCarrito(CreateCarritoRequestDto carritoDto)
        {
            
            List <ResponseGetProductoById> listaProductos = new List<ResponseGetProductoById> ();
            foreach (var item in carritoDto.Productos)
            {
                ResponseGetProductoById producto = _productoService.GetProductoById(item) ;
                listaProductos.Add(producto);
            }
            int total = CalcularPrecioTotal(listaProductos);
            var entity = new Carrito
            {
                CompradorId = carritoDto.CompradorId,
                PrecioTotal = total
            };
            _repository.Add(entity);

            foreach (ResponseGetProductoById item in listaProductos)
            {
                RegistrarProductoPedido(item.ProductoId, entity.CarritoId);
            }

            return new GenericsCreatedResponseDto { Entity = "Carrito", Id = entity.CarritoId.ToString() };
        }
        
        public int CalcularPrecioTotal(List<ResponseGetProductoById> productos)
        {
            int total = 0;
            List<ResponseGetProductoById> aux = productos;
            foreach (var item in aux)
            {
                total += item.Precio;
            }
            return total;
        }  

        private void RegistrarProductoPedido(int idproducto, int idcarrito)
        {
            var entity = new ProductoPedido
            {
                ProductoId = idproducto,
                CarritoId = idcarrito
            };
            _repository.Add(entity);

        }
    }
}
