/*
Héctor Vega
Fecha: 20/08/2026
Ejercicio: Tipos por Valor vs Tipos por Referencia práctica 
Segundo ejercicio para reforzar el mismo concepto diferencia de
comportamiento entre tipos por valor (int) y tipos por referencia
(arreglos) al asignarlos a otra variable.
*/

namespace PracticaValorReferencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = a;
            b = 50;

            Console.WriteLine($"Valor de a: {a}");
            Console.WriteLine($"Valor de b: {b}");

            int[] numeros = { 1, 2, 3 };
            int[] numbers = numeros;
            numbers[0] = 88;

            Console.WriteLine($"Referencia uno es: {numeros[0]}");

            Console.WriteLine($"Referencia dos es: {numbers[0]}");

            Console.WriteLine("Presiona una tecla para salir");
            Console.ReadKey();
        }
    }
}
