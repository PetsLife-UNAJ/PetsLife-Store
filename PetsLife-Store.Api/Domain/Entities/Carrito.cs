using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Carrito
    {
        public int CarritoId { get; set; }
        public int PrecioTotal { get; set; }

        public int CompradorId { get; set; }
        public Comprador Comprador { get; set; }
        public ICollection<ProductoPedido> ProductoPedidos { get; set; } 
         
    }
}
