using System.Collections.Generic;

namespace Domain.Entities
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public int PrecioTotal { get; set; }
        public int CompradorId { get; set; }
        public Comprador Comprador { get; set; }
        public ICollection<ProductoPedido> ProductoPedidos { get; set; } 
         
    }
}
