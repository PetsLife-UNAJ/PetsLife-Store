namespace Domain.DTOs
{
    public class AddProductoDTO
    {
        public string Nombre { get; set; }
        public int Categoria { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public int Rating { get; set; }
        public int CantidadStock { get; set; }
        public int Precio { get; set; }
       // public int TiendaId { get; set; }
    }

    public class GetProductoDTO
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public int Rating { get; set; }
        public int CantidadStock { get; set; }
        public int Precio { get; set; }
        public int TiendaId { get; set; }
    }
}
