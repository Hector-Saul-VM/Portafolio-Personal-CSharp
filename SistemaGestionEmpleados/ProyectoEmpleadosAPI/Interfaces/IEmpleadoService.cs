using ProyectoEmpleadosAPI.DTOs;

namespace ProyectoEmpleadosAPI.Interfaces
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<EmpleadoDTO>> ObtenerTodosAsync();
        Task<EmpleadoDTO> ObtenerPorIdAsync(int id);
        Task<EmpleadoDTO> CrearAsync(CrearEmpleadoDTO dto);
        Task ActualizarAsync(int id, CrearEmpleadoDTO dto);
        Task EliminarAsync(int id);
    }
}
