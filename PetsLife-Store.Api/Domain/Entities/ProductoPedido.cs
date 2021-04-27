using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductoPedido
    {
        public int ProductoPedidoId { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

    }
}
