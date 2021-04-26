using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Comprador
    {
        public int CompradorId { get; set; }
        public string Nombre { get; set; }

        public Carrito Carrito { get; set; }

    }
}
