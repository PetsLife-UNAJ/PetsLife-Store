using System.Collections.Generic;

namespace Domain.DTOs
{
    public class AddCarritoDTO
    {
        public int CarritoId { get; set; }
        public int PrecioTotal { get; set; }
        public int CompradorId { get; set; }
    }

    public class GetCarritoDTO
    {
        public int CarritoId { get; set; }
        public int PrecioTotal { get; set; }
        public GetCompradorDTO Comprador { get; set; }
        public List<GetProductoDTO> ProductoPedidos { get; set; }
    }
}
