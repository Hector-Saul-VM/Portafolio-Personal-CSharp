/*
Héctor Vega
Fecha: 21/08/2026
Ejercicio: Switch - Tipo de vehículo práctica 
Clasifica un vehículo como terrestre, acuático o aéreo usando switch
con múltiples case agrupados. Vuelve a pedir el dato si no es válido.
*/
namespace TipoVehiculo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool entradaValida = false;

            // Para entrar pregunta es false no cambia el valor de la variable, únicamente se puede cambiar con asignación, 
            while (!entradaValida)
            {
                Console.WriteLine("Ingresa un tipo de vehículo (auto, moto, barco, avión, helicóptero): ");
                string vehiculo = Console.ReadLine().ToLower(); // Convertimos todo a minúsculas para evitar errores

                switch (vehiculo)
                {
                    case "auto":
                    case "moto":
                    case "bicicleta":
                        Console.WriteLine("Es un vehículo terrestre.");
                        entradaValida = true;
                        break;

                    case "barco":
                    case "lancha":
                    case "submarino":
                        Console.WriteLine("Es un vehículo acuático.");
                        entradaValida = true;
                        break;

                    case "avión":
                    case "helicóptero":
                    case "dron":
                        Console.WriteLine("Es un vehículo aéreo.");
                        entradaValida = true;
                        break;

                    default:
                        Console.WriteLine("No reconozco ese tipo de vehículo. Intenta de nuevo.\n");
                        break;
                }
            }

            Console.WriteLine("¡Gracias por usar el programa!");
            Console.WriteLine("Presiona una tecla para continuar");
            Console.ReadKey();
        }
    }
}