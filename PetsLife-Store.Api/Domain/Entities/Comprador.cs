namespace Domain.Entities
{
    public class Comprador
    {
        public int CompradorId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        //public int CarritoId { get; set; }
        public Carrito Carrito { get; set; }

    }
}
