using AccessData.Commands.Repository;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Queries;
using System.Collections.Generic;

namespace Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericsRepository _repository;
        private readonly IProductoQuery _query;

        public ProductoService(IGenericsRepository repository, IProductoQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public List<GetProductoDTO> BuscarProductos(string producto)
        {
            return _query.BuscarProductos(producto);
        }

        public ResponseProductoDto CreateProducto(AddProductoDTO producto)
        {
            var entity = new Producto
            {
                Nombre = producto.Nombre,
                CategoriaId = producto.Categoria,
                Imagen = producto.Imagen,
                CantidadStock = producto.CantidadStock,
                Precio = producto.Precio,
                Descripcion = producto.Descripcion,
                Rating = producto.Rating,
                TiendaId = 1
            };

            _repository.Add<Producto>(entity);

            return new ResponseProductoDto
            {
                Entity = "Producto",
                Id = entity.ProductoId.ToString()
            };
        }

        public bool DeleteProducto(int id)
        {
            Producto producto = _repository.Exists<Producto>(id);
            if (producto == null)
            {
                return false;
            }
            else
            {
                _repository.Delete<Producto>(producto);
                return true;
            }
        }

        public GetProductoDTO GetProductoById(int id)
        {
            return _query.GetProductoById(id);
        }
        public List<GetProductoDTO> GetProductos(string categoria)
        {
            return _query.GetProductos(categoria);
        }

        public bool UpdateProducto(int id, AddProductoDTO productoDto)
        {
            Producto producto = _repository.Exists<Producto>(id);
            if (producto == null) return false;

            producto.Nombre = productoDto.Nombre;
            producto.CategoriaId = productoDto.Categoria;
            producto.Imagen = productoDto.Imagen;
            producto.CantidadStock = productoDto.CantidadStock;
            producto.Precio = productoDto.Precio;
            producto.Descripcion = productoDto.Descripcion;
            producto.Rating = productoDto.Rating;
            producto.TiendaId = 1;

            _repository.Update<Producto>(producto);
            return true;
        }

        public bool UpdateProductoStock(int idProducto, int newStock)
        {
            Producto producto = _repository.Exists<Producto>(idProducto);
            if (producto == null || newStock < 0) return false;

            producto.CantidadStock = newStock;
            _repository.Update(producto);

            return true;
        }
    }
}