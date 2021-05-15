using System.Collections.Generic;

namespace Domain.Entities
{
    public class Tienda
    {
        public int  TiendaId { get; set; }
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
