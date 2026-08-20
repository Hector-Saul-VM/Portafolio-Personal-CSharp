/*
Héctor Vega
Fecha: 20/08/2026
Ejercicio: Tipos por Valor vs Tipos por Referencia
Demuestra la diferencia de comportamiento entre tipos por valor (int)
y tipos por referencia (arreglos) al asignarlos a otra variable.
*/

namespace ValorVrsReferencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VALOR 
            int num1 = 5;
            int num2 = num1; // se copia el valor

            Console.WriteLine($"El valor del número 2 sin cambio es = {num2 }\n");

            num2 = 10; // cambio num2, pero num1 no se ve afectado

            Console.WriteLine("=== Tipos por valor ===");
            Console.WriteLine($"num1 = {num1}"); // sigue siendo 5
            Console.WriteLine($"num2 = {num2}"); // ahora es 10


            // REFERENCIA 
            int[] array1 = { 1, 2, 3 };
            int[] array2 = array1; // se copia la referencia los 2 apuntan a la misma variable

            array2[0] = 99; // cambio array2, pero también afecta a array1

            Console.WriteLine("\n=== Tipos por referencia ===");
            Console.WriteLine($"array1[0] = {array1[0]}");
            Console.WriteLine($"array2[0] = {array2[0]}");
        }
    }
}