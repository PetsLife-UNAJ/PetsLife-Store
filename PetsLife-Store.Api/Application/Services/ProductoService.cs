using AccessData.Commands.Repository;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Queries;
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

        public ProductoService(IGenericsRepository repository,IProductoQuery query)
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
            _repository.Add<Producto>(entity);

            return entity;
        }

       public ResponseGetProductoById GetProductoById(int id)
        {
            return _query.GetProductoById(id);
        }
        public List<ProductoDto> GetProductos()
        {
            return _query.GetProductos();//
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
