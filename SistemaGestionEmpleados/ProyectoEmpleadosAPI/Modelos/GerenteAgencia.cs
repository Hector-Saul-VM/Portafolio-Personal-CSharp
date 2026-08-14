namespace ProyectoEmpleadosAPI.Modelos
{
    public class GerenteAgencia: Empleado
    {
        public required string AgenciaAsignada { get; set; }
        public int NumeroEmpleadosACargo { get; set; }
        public bool AccesoADatosSensibles { get; set; } = true;

        public override string ObtenerDescripcion()
        {
            return $"Gerente de {AgenciaAsignada} con {NumeroEmpleadosACargo} empleados a cargo.";
        }
    }
}
