using ApiProductos.DTOs;
using ApiProductos.Models;

namespace ApiProductos.Services
{
    public interface IProductoService
    {
        //Task<IEnumerable<Producto>> ObtenerTodos();
        Task<IEnumerable<ProductoCreateDto>> ObtenerTodos();
        Task<Producto?> ObtenerPorId(int id);
        Task Crear(ProductoCreateDto dto);
        Task Actualizar(ProductoUpdateDto dto);
        Task Eliminar(int id);
    }
}