namespace ProyectoEmpleadosAPI.Modelos
{
    public abstract class PersonalExterno
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string? EmpresaExterna { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public bool EstaActivo { get; set; } = true;

        public abstract string ObtenerDescripcion();
    }
}