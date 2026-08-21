/*
Héctor Vega
Fecha: 21/08/2026
Ejercicio: Switch - Día de la semana práctica
Recibe un número del 1 al 5 y muestra el día correspondiente usando
switch, con validación segura de entrada mediante TryParse.
*/

namespace DiaSemana
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola ingresa un número del 1 al 5 para saber el día de la semana");
            if (int.TryParse(Console.ReadLine(), out int dia)) // Validación segura
            {
                switch (dia)
                {
                    case 1:
                        Console.WriteLine("El día es lunes");
                        break;
                    case 2:
                        Console.WriteLine("El día es martes");
                        break;
                    case 3:
                        Console.WriteLine("El día de la semana es miércoles");
                        break;
                    case 4:
                        Console.WriteLine("El día de la semana es jueves");
                        break;
                    case 5:
                        Console.WriteLine("El día de la semana es viernes");
                        break;
                    default:
                        Console.WriteLine("Ingreso un número incorrecto");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingresa solo números del 1 al 5.");
            }

            Console.WriteLine("Presiona una tecla para continuar");
            Console.ReadKey();
        }
    }
}
