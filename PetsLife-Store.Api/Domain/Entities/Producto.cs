using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }
        public int CantidadStock { get; set; }
        public int Precio { get; set; }
        public int TiendaId { get; set; }
      //  public Tienda Tienda { get; set; }
        // public ProductoPedido ProductoPedido { get; set; } 


    }
}
