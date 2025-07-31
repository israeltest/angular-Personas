using ApiProductos.DTOs;
using ApiProductos.Models;
using ApiProductos.Repositories;

namespace ApiProductos.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repo;

        public ProductoService(IProductoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProductoCreateDto>> ObtenerTodos() {
            var productosCons = await _repo.ObtenerProductos();
            var productosDto = productosCons.Select(p => new ProductoCreateDto
            {
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Categoria = p.Categoria,
                Imagen = p.Imagen,
                Precio = p.Precio,
                Stock = p.Stock
            });
            return productosDto;
        } //=> await _repo.ObtenerProductos();

        public async Task<Producto?> ObtenerPorId(int id) => await _repo.ObtenerProductoPorId(id);

        public async Task Crear(ProductoCreateDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Categoria = dto.Categoria,
                Imagen = dto.Imagen,
                Precio = dto.Precio,
                Stock = dto.Stock
            };
            await _repo.CrearProducto(producto);
        }

        public async Task Actualizar(ProductoUpdateDto dto)
        {
            var producto = new Producto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Categoria = dto.Categoria,
                Imagen = dto.Imagen,
                Precio = dto.Precio,
                Stock = dto.Stock
            };
            await _repo.ActualizarProducto(producto);
        }

        public async Task Eliminar(int id) => await _repo.EliminarProducto(id);
    }
}
