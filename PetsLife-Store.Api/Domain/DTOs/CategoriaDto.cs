namespace Domain.DTOs
{
    public class AddCategoriaDto
    {
        public string Descripcion { get; set; }
    }

    public class GetCategoriaDto
    {
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
    }

    public class ResponseCategoriaDto
    {
        public string CategoriaId { get; set; }
        public string Descripcion { get; set; }
    }
}
