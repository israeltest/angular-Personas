using ApiProductos.DTOs;
using ApiProductos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers
{
    // <summary>
    /// Controlador para gestionar las operaciones CRUD de productos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        /// <summary>
        /// Constructor del controlador que recibe el servicio de productos.
        /// </summary>
        /// <param name="service">Servicio para manejar la lógica de productos.</param>
        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene la lista de todos los productos.
        /// </summary>
        /// <returns>Una lista de productos.</returns>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ObtenerTodos());

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto a buscar.</param>
        /// <returns>El producto encontrado o NotFound si no existe.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _service.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="dto">DTO con los datos del producto a crear.</param>
        /// <returns>Mensaje de éxito.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.Crear(dto);
            return Ok(new { mensaje = "Producto creado exitosamente" });
        }

        /// <summary>
        /// Actualiza un producto existente por su ID.
        /// </summary>
        /// <param name="id">ID del producto a actualizar.</param>
        /// <param name="dto">DTO con los nuevos datos del producto.</param>
        /// <returns>Mensaje de éxito.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductoUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto.Id = id;
            await _service.Actualizar(dto);
            return Ok(new { mensaje = "Producto actualizado exitosamente" });
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto a eliminar.</param>
        /// <returns>Mensaje de éxito.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Eliminar(id);
            return Ok(new { mensaje = "Producto eliminado exitosamente" });
        }
    }
}
