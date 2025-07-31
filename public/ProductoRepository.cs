using ApiProductos.Datos;
using ApiProductos.Models;
using Dapper;
using System.Data;

namespace ApiProductos.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ContextoDapper _contexto;

        public ProductoRepository(ContextoDapper contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {

            using var connection = _contexto.CrearConexion();
            return await connection.QueryAsync<Producto>("sp_ObtenerProductos", commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Producto?> ObtenerProductoPorId(int id)
        {
            using var connection = _contexto.CrearConexion();
            return await connection.QueryFirstOrDefaultAsync<Producto>("sp_ObtenerProductoPorId", new { Id = id }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task CrearProducto(Producto producto)
        {
            using var connection = _contexto.CrearConexion();
            await connection.ExecuteAsync("sp_CrearProducto", new
            {
                producto.Nombre,
                producto.Descripcion,
                producto.Categoria,
                producto.Imagen,
                producto.Precio,
                producto.Stock
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task ActualizarProducto(Producto producto)
        {
            using var connection = _contexto.CrearConexion();
            await connection.ExecuteAsync("sp_ActualizarProducto", producto, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task EliminarProducto(int id)
        {
            using var connection = _contexto.CrearConexion();
            await connection.ExecuteAsync("sp_EliminarProducto", new { Id = id }, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
