using Microsoft.AspNetCore.Mvc;
using ProyectoEmpleadosAPI.DTOs;
using ProyectoEmpleadosAPI.Interfaces;

namespace ProyectoEmpleadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: api/Empleados
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> GetEmpleados()
        {
            var empleados = await _empleadoService.ObtenerTodosAsync();
            return Ok(empleados);
        }

        // GET: api/Empleados/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoDTO>> GetEmpleadoPorId(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser un número positivo.");

            var empleado = await _empleadoService.ObtenerPorIdAsync(id);

            if (empleado == null)
                return NotFound($"No se encontró el empleado con ID {id}");

            return Ok(empleado);
        }

        // POST: api/Empleados
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmpleadoDTO>> CrearEmpleado([FromBody] CrearEmpleadoDTO dto)
        {
            try
            {
                var nuevoEmpleado = await _empleadoService.CrearAsync(dto);
                return CreatedAtAction(nameof(GetEmpleadoPorId), new { id = nuevoEmpleado.Id }, nuevoEmpleado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocurrió un error al crear el empleado.");
            }
        }

        // PUT: api/Empleados/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarEmpleado(int id, [FromBody] CrearEmpleadoDTO dto)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser un número positivo.");

            try
            {
                await _empleadoService.ActualizarAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocurrió un error al actualizar el empleado.");
            }
        }

        // DELETE: api/Empleados/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarEmpleado(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser un número positivo.");

            try
            {
                await _empleadoService.EliminarAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocurrió un error al eliminar el empleado.");
            }
        }
    }
}