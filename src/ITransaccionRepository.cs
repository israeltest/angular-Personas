using ApiTransacciones.DTOs;
using ApiTransacciones.Models;

namespace ApiTransacciones.Repositories
{
    public interface ITransaccionRepository
    {
        Task RegistrarTransaccion(TransaccionCreateDto dto);
        Task<IEnumerable<Transaccion>> ObtenerTransaccionesFiltrado(int? productoId, string? tipo, DateTime? desde, DateTime? hasta);
    }
}