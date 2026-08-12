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
        public ActionResult<Empleado> GetEmpleadoPorId(int id)
        {
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
    }
}
