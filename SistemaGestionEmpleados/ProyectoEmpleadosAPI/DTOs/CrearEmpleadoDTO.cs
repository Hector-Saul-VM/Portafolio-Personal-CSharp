namespace ProyectoEmpleadosAPI.DTOs
{
    public class CrearEmpleadoDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal Salario { get; set; }
        public string Departamento { get; set; }
        public string Oficina { get; set; }
        public string TipoEmpleado { get; set; } // 👈 El Frontend envía el tipo
    }
}
