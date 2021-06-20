using Domain.DTOs;
using System.Collections.Generic;

namespace Domain.Interfaces.Queries
{
    public interface IProductoQuery
    {
        public GetProductoDTO GetProductoById(int id);
        public List<GetProductoDTO> GetProductos(string categoria);

    }
}
