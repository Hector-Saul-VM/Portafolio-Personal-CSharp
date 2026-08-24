/*
 * Autor: Héctor Vega
 * Fecha: 21/08/2026
 * Ejercicio: Clasificador de Números con Centinela
 * Descripción: Lee números por consola, los clasifica en positivos/negativos
 * y calcula la suma de los positivos hasta que se ingresa un 0.
 * Incluye manejo de excepciones con int.TryParse y continue.
 */

namespace ClasificadorNumerosCentinela
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa números (0 para terminar):");

            int contadorPositivo = 0;
            int contadorNegativo = 0;
            int sumaPositivos = 0;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int numero))
                {
                    Console.WriteLine("Debe ingresar solo números enteros");
                    continue; // Regresa al inicio del bucle sin alteración de contadores
                }

                // Verificar condición de salida (centinela)
                if (numero == 0)
                {
                    break; // Sale del bucle 
                }

                if (numero > 0)
                {
                    contadorPositivo++;
                    sumaPositivos += numero;
                }
                else if (numero < 0)
                {
                    contadorNegativo++;
                }
            }

            Console.WriteLine($"Total positivos: {contadorPositivo}");
            Console.WriteLine($"Total negativos: {contadorNegativo}");
            Console.WriteLine($"Suma de positivos: {sumaPositivos}");
        }
    }
}
