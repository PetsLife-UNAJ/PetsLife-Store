namespace Domain.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public int Rating { get; set; }
        public int CantidadStock { get; set; }
        public int Precio { get; set; }
        public int TiendaId { get; set; }
        public int CategoriaId { get; set; }
        public Categoria CategoriaNavigator { get; set; }

    }
}
