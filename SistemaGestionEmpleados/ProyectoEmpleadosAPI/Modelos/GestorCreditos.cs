namespace ProyectoEmpleadosAPI.Modelos
{
    public class GestorCreditos : Empleado
    {
        public decimal LimiteCreditoAutorizable { get; set; }
        public int NumeroClientesAsignados { get; set; }
        public bool PuedeAbrirCuentas { get; set; } = true;
        public bool PuedeVenderSeguros { get; set; } = true;

        public override string ObtenerDescripcion()
        {
            return $"Gestor de créditos con {NumeroClientesAsignados} clientes. Límite: {LimiteCreditoAutorizable:C}";
        }
    }
}