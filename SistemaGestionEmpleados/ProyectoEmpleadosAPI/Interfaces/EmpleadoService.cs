using Microsoft.EntityFrameworkCore;
using ProyectoEmpleadosAPI.Datos;
using ProyectoEmpleadosAPI.DTOs;
using ProyectoEmpleadosAPI.Interfaces;
using ProyectoEmpleadosAPI.Modelos;

namespace ProyectoEmpleadosAPI.Servicios
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpleadoDTO>> ObtenerTodosAsync()
        {
            var empleados = await _context.Empleados.ToListAsync();

            return empleados.Select(e =>
            {
                var tipo = e switch
                {
                    GerenteAgencia => "Gerente",
                    GestorCreditos => "Gestor",
                    Cajero => "Cajero",
                    _ => "Empleado"
                };

                return new EmpleadoDTO
                {
                    Id = e.Id,
                    NombreCompleto = $"{e.Nombre} {e.Apellido}",
                    Email = e.Email,
                    Departamento = e.Departamento,
                    Oficina = e.Oficina,
                    TipoEmpleado = tipo
                };
            });
        }

        public async Task<EmpleadoDTO> ObtenerPorIdAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return null;

            var tipo = empleado switch
            {
                GerenteAgencia => "Gerente",
                GestorCreditos => "Gestor",
                Cajero => "Cajero",
                _ => "Empleado"
            };

            return new EmpleadoDTO
            {
                Id = empleado.Id,
                NombreCompleto = $"{empleado.Nombre} {empleado.Apellido}",
                Email = empleado.Email,
                Departamento = empleado.Departamento,
                Oficina = empleado.Oficina,
                TipoEmpleado = tipo
            };
        }

        public async Task<EmpleadoDTO> CrearAsync(CrearEmpleadoDTO dto)
        {
            Empleado nuevoEmpleado = dto.TipoEmpleado switch
            {
                "Gerente" => new GerenteAgencia
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    Telefono = dto.Telefono,
                    FechaContratacion = dto.FechaContratacion,
                    Salario = dto.Salario,
                    Departamento = dto.Departamento,
                    Oficina = dto.Oficina,
                    AgenciaAsignada = dto.Oficina ?? "Agencia Principal",
                    NumeroEmpleadosACargo = 0
                },
                "Gestor" => new GestorCreditos
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    Telefono = dto.Telefono,
                    FechaContratacion = dto.FechaContratacion,
                    Salario = dto.Salario,
                    Departamento = dto.Departamento,
                    Oficina = dto.Oficina,
                    LimiteCreditoAutorizable = 50000m,
                    NumeroClientesAsignados = 0
                },
                "Cajero" => new Cajero
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    Telefono = dto.Telefono,
                    FechaContratacion = dto.FechaContratacion,
                    Salario = dto.Salario,
                    Departamento = dto.Departamento,
                    Oficina = dto.Oficina,
                    NumeroCaja = "001",
                    ManejaEfectivo = true
                },
                _ => throw new ArgumentException($"Tipo de empleado '{dto.TipoEmpleado}' no válido.")
            };

            _context.Empleados.Add(nuevoEmpleado);
            await _context.SaveChangesAsync();

            return new EmpleadoDTO
            {
                Id = nuevoEmpleado.Id,
                NombreCompleto = $"{nuevoEmpleado.Nombre} {nuevoEmpleado.Apellido}",
                Email = nuevoEmpleado.Email,
                Departamento = nuevoEmpleado.Departamento,
                Oficina = nuevoEmpleado.Oficina,
                TipoEmpleado = dto.TipoEmpleado
            };
        }

        public async Task ActualizarAsync(int id, CrearEmpleadoDTO dto)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
                throw new KeyNotFoundException($"Empleado con ID {id} no encontrado.");

            empleado.Nombre = dto.Nombre;
            empleado.Apellido = dto.Apellido;
            empleado.Email = dto.Email;
            empleado.Telefono = dto.Telefono;
            empleado.FechaContratacion = dto.FechaContratacion;
            empleado.Salario = dto.Salario;
            empleado.Departamento = dto.Departamento;
            empleado.Oficina = dto.Oficina;

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
                throw new KeyNotFoundException($"Empleado con ID {id} no encontrado.");

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
        }
    }
}