namespace PrimerProyecto_API.DTOs
{
    public class EmpleadoCreacionDTO
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public decimal Salario { get; set; }
        // ❌ No tiene Id (lo genera la base de datos)
    }
}
