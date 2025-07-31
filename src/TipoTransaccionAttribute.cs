using System.ComponentModel.DataAnnotations;

namespace ApiTransacciones.DTOs
{
    public class TipoTransaccionAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var tipo = value?.ToString()?.ToLower();
            if (tipo == "venta" || tipo == "compra")
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage ?? "El tipo de transacción debe ser 'Venta' o 'Compra'.");
        }
    }
}
