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

    }
}
