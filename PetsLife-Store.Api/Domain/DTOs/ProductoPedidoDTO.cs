namespace Domain.DTOs
{
    public class AddProductoPedidoDTO
    {
        public int ProductoId { get; set; }
        public int CarritoId { get; set; }
    }

    public class GetProductoPedidoDTO
    {
        public int ProductoPedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int CarritoId { get; set; }

    }
}
