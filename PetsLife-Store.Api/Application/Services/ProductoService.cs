using AccessData.Commands.Repository;
using AccessData.Validation;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Producto CreateProducto(ProductoDto producto)
        {
            var entity = new Producto
            {
                Nombre = producto.Nombre,
                Categoria = producto.Categoria,
                Imagen = producto.Imagen,
                CantidadStock = producto.CantidadStock,
                Precio = producto.Precio,
                TiendaId = 1
            };

            ProductoValidator validator = new ProductoValidator();
            validator.ValidateAndThrow(entity);

            _repository.Add<Producto>(entity);

            return entity;
        }

        public bool DeleteProducto(int id)
        {
            Producto producto = _repository.Exists<Producto>(id);
            if(producto == null)
            {
                return false;
            }
            else
            {
                _repository.Delete<Producto>(producto);
                return true;
            }
        }

        public ResponseGetProductoById GetProductoById(int id)
        {
            return _query.GetProductoById(id);
        }
        public List<ProductoDto> GetProductos()
        {
            return _query.GetProductos();
        }

        public bool UpdateProducto(int id, ProductoDto productoDto)
        {
            Producto producto = _repository.Exists<Producto>(id);
            if(producto == null) return false;

            producto.Nombre = productoDto.Nombre;
            producto.Categoria = productoDto.Categoria;
            producto.Imagen = productoDto.Imagen;
            producto.CantidadStock = productoDto.CantidadStock;
            producto.Precio = productoDto.Precio;
            producto.TiendaId = 1;

            ProductoValidator validator = new();
            validator.ValidateAndThrow(producto);

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


        //public IQueryable GetProductoById(int id)
        //{
        //  return  _repository.GetProductoById(id);
        //}
        //public IQueryable GetProductos()
        //{
        //    return _repository.GetProductos();
        //}
    }
}
