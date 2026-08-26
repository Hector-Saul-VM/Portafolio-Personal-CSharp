/*
 * Autor: Héctor Vega
 * Fecha: 26/08/2026
 * Ejercicio: Contar y Clasificar Números
 * Descripción:
 *   Toma una lista de números y clasifica:
 *   1. Cuenta cuántos números son pares e impares.
 *   2. Suma los números pares y los impares por separado.
 *   3. Muestra los resultados.
 * 
 * Aprendizaje:
 *   - Uso de listas (List<int>)
 *   - Bucle for para recorrer listas
 *   - Operador módulo (%) para clasificar pares/impares
 *   - Acumuladores (contadores y sumas)
 *   - Interpolación de cadenas ($"...")
 */

namespace ContarClasificarNumerosParImpar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 2, 5, 8, 11, 14, 17, 20, 23 };

            int paresContador = 0;
            int imparesContador = 0;

            int sumaPares = 0;
            int sumaImpares = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)  // Si es par
                {
                    paresContador++;
                    sumaPares += list[i];
                }
                else
                {
                    imparesContador++;
                    sumaImpares += list[i];
                }
            }
            Console.WriteLine($"Pares: {paresContador}");
            Console.WriteLine($"Impares: {imparesContador}");
            Console.WriteLine($"Suma pares: {sumaPares}");
            Console.WriteLine($"Suma impares: {sumaImpares}");
        }
    }
}
