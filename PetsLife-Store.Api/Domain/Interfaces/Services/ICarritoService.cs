using Domain.DTOs;

namespace Domain.Interfaces.Services
{
    public interface ICarritoService
    {
        public GetCarritoDTO GetCarritoById(int id);
        public int CalcularPrecioTotal(GetProductoDTO producto , GetCarritoDTO carrito);
        public GetProductoPedidoDTO AddProductoPedido(AddProductoPedidoDTO productoPedidoDTO);
        public bool RemoveProductoPedidoFromCarrito(int idProductoPedido);
    }
}
