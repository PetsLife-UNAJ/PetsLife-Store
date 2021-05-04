using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CarritoDTO
    {
        public List<ProductoPedido> ProductoPedidos { get; set; }
        public int PrecioTotal { get; set; }
        public int CompradorId { get; set; }

    }
}
