using ApiTransacciones.DTOs;
using ApiTransacciones.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ApiTransacciones.Repositories
{
    public class TransaccionRepository : ITransaccionRepository
    {
        private readonly string _connectionString;

        public TransaccionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task RegistrarTransaccion(TransaccionCreateDto dto)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("sp_RegistrarTransaccion", new
            {
                dto.TipoTransaccion,
                dto.ProductoId,
                dto.Cantidad,
                dto.PrecioUnitario,
                dto.Detalle
            }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Transaccion>> ObtenerTransaccionesFiltrado(int? productoId, string? tipo, DateTime? desde, DateTime? hasta)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Transaccion>("sp_ObtenerTransaccionesFiltrado", new
            {
                ProductoId = productoId,
                TipoTransaccion = tipo,
                FechaInicio = desde,
                FechaFin = hasta
            }, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
