using ApiTransacciones.Data;
using ApiTransacciones.DTOs;
using ApiTransacciones.Models;
using ApiTransacciones.Repositories;

namespace ApiTransacciones.Services
{
    public class TransaccionService : ITransaccionService
    {
        private readonly ITransaccionRepository _repo;
        private readonly ProductoApiClient _productoApi;

        public TransaccionService(ITransaccionRepository repo, ProductoApiClient productoApi)
        {
            _repo = repo;
            _productoApi = productoApi;
        }

        public async Task RegistrarTransaccion(TransaccionCreateDto dto)
        {
            if (dto.TipoTransaccion == "Venta")
            {
                var producto = await _productoApi.ObtenerProducto(dto.ProductoId);
                if (producto == null)
                    throw new Exception("Producto no encontrado");

                if (producto.Stock < dto.Cantidad)
                    throw new Exception("Stock insuficiente");
            }

            await _repo.RegistrarTransaccion(dto);
        }

        public async Task<IEnumerable<Transaccion>> ObtenerTransaccionesFiltrado(int? productoId, string? tipo, DateTime? desde, DateTime? hasta)
        {
            return await _repo.ObtenerTransaccionesFiltrado(productoId, tipo, desde, hasta);
        }
    }
}