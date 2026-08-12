using PrimerProyecto_API.DTOs;

namespace PrimerProyecto_API.Servicios
{
    public interface IEmpleadoService
    {
        IEnumerable<EmpleadoDTO> ObtenerTodos();
        EmpleadoDTO ObtenerPorId(int id);
    }
}
