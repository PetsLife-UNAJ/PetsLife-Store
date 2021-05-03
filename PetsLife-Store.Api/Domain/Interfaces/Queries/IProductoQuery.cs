using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Queries
{
   public interface IProductoQuery
    {

        public List<ProductoDto> GetProductoById(int id);
        public List<ProductoDto> GetProductos();

    }
}
