namespace ProyectoEmpleadosAPI.Modelos
{
    public class Conserje : PersonalExterno
    {
        public string? DepartamentoAsignado { get; set; }
        public string? Turno { get; set; }

        public override string ObtenerDescripcion()
        {
            return $"Conserje en {DepartamentoAsignado ?? "el banco"} (Turno: {Turno ?? "No especificado"}).";
        }
    }
}