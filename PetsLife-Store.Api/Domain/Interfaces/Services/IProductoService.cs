using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductoService
    {
        Producto CreateProducto(ProductoDto producto);
        public ResponseGetProductoById GetProductoById(int id);
        public List<ProductoDto> GetProductos();
        bool DeleteProducto(int id);
        bool UpdateProducto(int id, ProductoDto productoDto);

    }
}
