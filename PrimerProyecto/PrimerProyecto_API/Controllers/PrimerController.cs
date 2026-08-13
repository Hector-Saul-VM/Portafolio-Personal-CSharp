using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PrimerProyecto_API.DTOs;
using PrimerProyecto_API.Modelos;

namespace PrimerProyecto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimerController : ControllerBase
    {
        private static List<Empleado> _empleados = new List<Empleado>
        {
            new Empleado { Id = 87, Nombre = "Ana", Direccion = "Palencia"},
            new Empleado { Id = 92, Nombre = "Héctor", Direccion = "Pinula"}
        };

        /// <summary>
        /// Obtiene una secuencia de empleados que puede ser enumerada.
        /// No importa si internamente proviene de una lista, un arreglo,
        /// una consulta u otra colección compatible con IEnumerable.
        /// La secuencia puede contener cero, uno o varios empleados.
        /// No recibe un objeto individual Empleado, sino una secuencia
        /// que pueda ser enumerada y cuyos elementos sean de tipo Empleado.
        /// </summary>
        /// <returns>Una secuencia enumerable de objetos Empleado.</returns>
        [HttpGet]
        public IEnumerable<Empleado> GetEmpleados()
        {
            return new List<Empleado>
            {
                new Empleado {Id = 87, Nombre = "Ana Cifuentes", Direccion = "Palencia"},
                new Empleado {Id = 92, Nombre = "Héctor Vega", Direccion = "Pinula"}
            };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Empleado> GetEmpleadoPorId(int id)
        {
            // Validamos que el ID sea válido
            if (id <= 0)
            {
                return BadRequest("El ID debe ser un número positivo.");
            }

            // ✅ Lista de empleados (puedes usar la misma que tienes en GetEmpleados)
            var empleados = new List<Empleado>
            {
                new Empleado { Id = 87, Nombre = "Ana", Direccion = "Palencia" },
                new Empleado { Id = 92, Nombre = "Héctor", Direccion = "Pinula" }
            };

            // ✅ Buscar el empleado por ID
            var empleado = empleados.FirstOrDefault(e => e.Id == id);

            // ✅ Si no existe, devolver 404
            if (empleado == null)
            {
                return NotFound($"No se encontró el empleado con ID {id}");
            }

            // ✅ Si existe, devolverlo con 200 OK
            return Ok(empleado);
        }

        // ============================================================
        // 🟢 MÉTODO 2: CON ActionResult (VERSIÓN PROFESIONAL)
        // ============================================================
        /// <summary>
        /// Obtiene una lista de empleados con control de códigos HTTP.
        /// </summary>
        /// <returns>Una lista de objetos Empleado con código 200 OK.</returns>
        /// <response code="200">Devuelve la lista de empleados.</response>
        [HttpGet("profesional")]  // 👈 URL: /api/Primer/profesional
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<EmpleadoDTO>> GetEmpleadosProfesional()
        {
            var empleados = new List<EmpleadoDTO>
            {
                new EmpleadoDTO { Id = 87, Nombre = "Ana Cifuentes", Edad = 34 },
                new EmpleadoDTO { Id = 92, Nombre = "Héctor Vega", Edad = 34 }
            };

            return Ok(empleados);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmpleadoDTO> CrearEmpleado([FromBody] EmpleadoCreacionDTO empleadoDTO)
        {
            // 1️⃣ Validar que el DTO no sea null
            if (empleadoDTO == null)
            {
                return BadRequest("Los datos del empleado son inválidos.");
            }

            // 2️⃣ Validar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(empleadoDTO.Nombre))
            {
                return BadRequest("El nombre del empleado es obligatorio.");
            }

            // 3️⃣ Validar que el salario sea positivo
            if (empleadoDTO.Salario <= 0)
            {
                return BadRequest("El salario debe ser un número positivo.");
            }

            try
            {
                // 4️⃣ Crear el empleado (solo en memoria)
                var nuevoEmpleado = new Empleado
                {
                    Id = _empleados.Count > 0 ? _empleados.Max(e => e.Id) + 1 : 1,
                    Nombre = empleadoDTO.Nombre,
                    Direccion = empleadoDTO.Direccion,
                };

                // 5️⃣ Guardar en la lista en memoria
                _empleados.Add(nuevoEmpleado);

                // 6️⃣ Mapear a DTO para la respuesta
                var resultadoDTO = new EmpleadoDTO
                {
                    Id = nuevoEmpleado.Id,
                    Nombre = nuevoEmpleado.Nombre,
                    Edad = 0 // O calcular si tienes fecha de nacimiento
                };

                // 7️⃣ Devolver 201 Created con la ubicación del nuevo recurso
                return CreatedAtAction(nameof(GetEmpleadoPorId), new { id = nuevoEmpleado.Id }, resultadoDTO);
            }
            catch (Exception)
            {
                // 8️⃣ Si algo explota, devolver 500 con un mensaje genérico
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocurrió un error al crear el empleado.");
            }
        }
    }
}
