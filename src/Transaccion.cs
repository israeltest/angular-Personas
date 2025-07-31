namespace ApiTransacciones.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoTransaccion { get; set; } = null!;
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal => Cantidad * PrecioUnitario;
        public string? Detalle { get; set; }
        public string? NombreProducto { get; set; }
        public int Stock { get; set; }



    }
}
