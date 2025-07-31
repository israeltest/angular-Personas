namespace ApiTransacciones.Models
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Stock { get; set; }
    }
}
