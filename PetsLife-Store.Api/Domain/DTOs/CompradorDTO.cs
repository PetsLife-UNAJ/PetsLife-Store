using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class AddCompradorDTO
    {

    }

    public class GetCompradorDTO
    {
        public int CompradorId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}
