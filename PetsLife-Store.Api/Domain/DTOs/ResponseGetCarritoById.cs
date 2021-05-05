using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ResponseGetCarritoById
    {
       
        public int CarritoId { get; set; }
        public int PrecioTotal { get; set; }
        public ResponseGetCarritoByIdComprador Comprador { get; set; }
        public List<ResponseGetProductoById> ProductoPedidos { get; set; }
    }

    public class ResponseGetCarritoByIdComprador
    {
        public int CompradorId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}
