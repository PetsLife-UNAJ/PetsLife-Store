using AccessData.Commands.Repository;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{   
    public interface IProductoService
    {
        Producto CreateProducto(ProductoDto producto);
    }
    public class ProductoService : IProductoService
    {
        private readonly IGenericsRepository _repository;
        public ProductoService(IGenericsRepository repository)
        {
            _repository = repository;
        }
        public Producto CreateProducto(ProductoDto producto)
        {
            var entity = new Producto
            {
                Nombre = producto.Nombre,
                Categoria = producto.Categoria,
                Imagen = producto.Imagen,
                CantidadStock = producto.CantidadStock,
                Precio = producto.Precio
            };
            _repository.Add<Producto>(entity);

            return entity;
        }
    }
}
