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
        public List<ProductoDto> GetProductoById(int id);
        public List<ProductoDto> GetProductos();

    }
}
