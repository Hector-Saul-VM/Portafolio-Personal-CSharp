namespace ProyectoEmpleadosAPI.DTOs
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }  // 👈 concatenas Nombre + Apellido
        public string Email { get; set; }
        public string Departamento { get; set; }
        public string Oficina { get; set; }
        public string TipoEmpleado { get; set; } // 👈 "Gerente", "Cajero", etc.
    }
}
