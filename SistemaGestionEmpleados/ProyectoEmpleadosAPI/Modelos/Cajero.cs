namespace ProyectoEmpleadosAPI.Modelos
{
    public class Cajero : Empleado
    {
        public required string NumeroCaja { get; set; }
        public bool ManejaEfectivo { get; set; } = true;
        public bool PuedePagarCheques { get; set; } = true;
        public bool PuedeHacerDepositos { get; set; } = true;

        public override string ObtenerDescripcion()
        {
            return $"Cajero en caja {NumeroCaja}.";
        }
    }
}