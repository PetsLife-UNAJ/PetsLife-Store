using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IProductoService
    {
        Producto CreateProducto(AddProductoDTO producto);
        public GetProductoDTO GetProductoById(int id);
        public List<GetProductoDTO> GetProductos(string categoria);
        bool DeleteProducto(int id);
        bool UpdateProducto(int id, AddProductoDTO productoDto);
        public bool UpdateProductoStock(int idProducto, int newStock);

    }
}
