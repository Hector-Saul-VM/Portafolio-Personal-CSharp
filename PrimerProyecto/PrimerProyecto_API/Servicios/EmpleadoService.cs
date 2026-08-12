using PrimerProyecto_API.DTOs;
using PrimerProyecto_API.Modelos;

namespace PrimerProyecto_API.Servicios
{
    public class EmpleadoService : IEmpleadoService
    {
        // 📦 Datos en memoria (simulando una base de datos)
        private readonly List<Empleado> _empleados = new List<Empleado>
        {
            new Empleado { Id = 87, Nombre = "Ana", Direccion = "Palencia" },
            new Empleado { Id = 92, Nombre = "Héctor", Direccion = "Pinula" }
        };

        public IEnumerable<EmpleadoDTO> ObtenerTodos()
        {
            return _empleados.Select(e => new EmpleadoDTO
            {
                Id = e.Id,
                Nombre = e.Nombre
            });
        }

        public EmpleadoDTO ObtenerPorId(int id)
        {
            var empleado = _empleados.FirstOrDefault(e => e.Id == id);
            if (empleado == null) return null;

            return new EmpleadoDTO
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre
            };
        }
    }
}