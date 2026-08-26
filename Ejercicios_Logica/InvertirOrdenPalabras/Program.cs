/*
 * Autor: Héctor Vega
 * Fecha: 26/08/2026
 * Ejercicio: Inversor de Orden de Palabras
 * Descripción: Lee una frase por consola, la divide en palabras
 * y las muestra en orden inverso (de la última a la primera).
 * Incluye control para evitar espacios al final.
 */

namespace InvertirOrdenPalabras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola ingresa una frase:");
            string frase = Console.ReadLine();

            // Separar la frase en palabras
            string[] palabras = frase.Split(' ');

            // Recorrer el arreglo al revés
            for (int i = palabras.Length - 1; i >= 0; i--)
            {
                Console.Write(palabras[i]);

                // Para evitar espacio al final 
                if (i != 0)
                {
                    Console.Write(" ");
                }
            }
        }
    }
}
