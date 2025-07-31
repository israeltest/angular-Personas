using ApiProductos.Models;

namespace ApiProductos.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerProductos();
        Task<Producto?> ObtenerProductoPorId(int id);
        Task CrearProducto(Producto producto);
        Task ActualizarProducto(Producto producto);
        Task EliminarProducto(int id);
    }
}