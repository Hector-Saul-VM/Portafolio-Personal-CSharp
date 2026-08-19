namespace ProyectoEmpleadosAPI.DTOs
{
    public class CrearPersonalExternoDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string EmpresaExterna { get; set; }
        public string TipoPersonal { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
    }
}
