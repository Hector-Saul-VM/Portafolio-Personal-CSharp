/*
Héctor Vega
Fecha: 20/08/2026
Ejercicio números primos
menores o iguales a 1 no son primos
*/

namespace EjercicioNumeroPrimo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Por favor, ingresa un número: ");

            int numeroUsuario = int.Parse(Console.ReadLine());
            bool resultado = EsPrimo(numeroUsuario);

            if (resultado )
            {
                Console.WriteLine($"El número {numeroUsuario} Sí es primo.");
            }
            else
            {
                Console.WriteLine($"El número {numeroUsuario} No es primo.");
            }
        }

        static bool EsPrimo(int numero)
        {
            if (numero <= 1)
            {
                return false;
            }

            // Empezamos desde el 2 hasta la raíz cuadrada del número guardada como entero
            int limite = (int)Math.Sqrt(numero);
            for (int i = 2; i <= limite; i++)
            {
                if (numero % i == 0)
                {
                    return false; 
                }
            }
            // Si el ciclo terminó y nadie lo pudo dividir exactamente, entonces SÍ es primo
            return true;
        }
    }
}
