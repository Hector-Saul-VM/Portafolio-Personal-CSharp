namespace ProyectoEmpleadosAPI.Modelos
{
    public abstract class Empleado
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal Salario { get; set; }
        public bool EstaActivo { get; set; } = true;
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }

        // Propiedades comunes a todos los empleados del banco
        public string? Departamento { get; set; }
        public string? Oficina { get; set; }

        // Método que todos los empleados deben implementar
        public abstract string ObtenerDescripcion();
    }
}