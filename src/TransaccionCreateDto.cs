using System.ComponentModel.DataAnnotations;

namespace ApiTransacciones.DTOs
{
    public class TransaccionCreateDto
    {
        [Required(ErrorMessage = "El tipo de transacción es obligatorio.")]
        [TipoTransaccion(ErrorMessage = "El tipo de transacción debe ser 'Venta' o 'Compra'.")]
        public string TipoTransaccion { get; set; } = null!;

        [Required(ErrorMessage = "El producto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un producto válido.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a cero.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor a 0.")]
        public decimal PrecioUnitario { get; set; }

        [StringLength(250, ErrorMessage = "El detalle no debe superar los 250 caracteres.")]
        public string? Detalle { get; set; }
    }
}
