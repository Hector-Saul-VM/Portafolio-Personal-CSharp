// Héctor Vega
// Fecha: 20/08/2026
// Ejercicio FizzBuzz
// Imprime del 1 al 100. Múltiplos de 3 -> "Fizz", de 5 -> "Buzz",
// de ambos -> "FizzBuzz", si no aplica ninguno -> el número.

namespace EjercicioLogicaFizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mayor = 100;
   
            for (int i = 1; i <= mayor; i++)
            {
                // Se evalúa primero el caso más específico (múltiplo de ambos)
                // para que no lo "atrape" antes la condición de solo Fizz o solo Buzz.

                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }

                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }

                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                
                else
                {
                    Console.WriteLine($"El número es: {i}");
                }
            }        
        }
    }
}

