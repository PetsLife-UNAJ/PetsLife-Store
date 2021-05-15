using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.Queries
{
    public interface ICarritoQuery
    {
        public GetCarritoDTO GetCarritoById(int id);
        public ProductoPedido GetProductoPedidoById(int idProductoPedido);
    }
}
