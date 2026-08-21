/*
Héctor Vega
Fecha: 21/08/2026
Ejercicio: Switch - Calificaciones con letras
Descripción:
Solicitar al usuario una calificación representada por una letra
(A, B, C, D o F), validar que la entrada sea correcta y utilizar
switch para mostrar el mensaje correspondiente a cada calificación.
*/
namespace EjerciciosSwitchPersonalesPorMiDesdeCero
{
    internal class CalificacionesConLetras
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa una calificación en letras (A, B, C, D, F):");
            string calificacion = Console.ReadLine().ToUpper();  // Convierte a mayúsculas para evitar errores con "a" o "A"

            // Validar que solo se ingrese una letra y que sea válida al objeto string "ABCDF"
            // Si se ingresa más de una letra no entra al if
            if (calificacion.Length == 1 && "ABCDF".Contains(calificacion))
            {
                // Evaluamos la calificación con switch
                switch (calificacion)
                {
                    case "A":
                        Console.WriteLine("¡Excelente!");
                        break;
                    case "B":
                        Console.WriteLine("¡Bien!");
                        break;
                    case "C":
                        Console.WriteLine("Regular");
                        break;
                    case "D":
                        Console.WriteLine("Reprobado");
                        break;
                    case "F":
                        Console.WriteLine("Reprobado");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingresa solo una letra válida (A, B, C, D, F).");
            }

            Console.WriteLine("¡Gracias por usar el programa!");
        }
    }
}