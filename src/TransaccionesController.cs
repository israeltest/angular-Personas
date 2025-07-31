using ApiTransacciones.DTOs;
using ApiTransacciones.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTransacciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionesController : ControllerBase
    {
        private readonly ITransaccionService _service;

        public TransaccionesController(ITransaccionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] TransaccionCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _service.RegistrarTransaccion(dto);
                return Ok(new { mensaje = "Transacción registrada correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Filtrar(
            int? productoId,
            string? tipo,
            DateTime? desde,
            DateTime? hasta)
        {
            var result = await _service.ObtenerTransaccionesFiltrado(productoId, tipo, desde, hasta);
            return Ok(result);
        }
    }
}
