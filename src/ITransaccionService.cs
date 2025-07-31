using ApiTransacciones.DTOs;
using ApiTransacciones.Models;

namespace ApiTransacciones.Services
{
    public interface ITransaccionService
    {
        Task RegistrarTransaccion(TransaccionCreateDto dto);
        Task<IEnumerable<Transaccion>> ObtenerTransaccionesFiltrado(int? productoId, string? tipo, DateTime? desde, DateTime? hasta);
    }
}