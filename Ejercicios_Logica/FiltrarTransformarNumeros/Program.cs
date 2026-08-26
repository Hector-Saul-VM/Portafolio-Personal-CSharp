/*
 * Autor: Héctor Vega
 * Fecha: 26/08/2026
 * Ejercicio: Filtrar y Transformar Números
 * Descripción:
 *   1. Filtra una lista de números, eliminando los que NO son múltiplos de 5.
 *   2. Transforma los números restantes:
 *      - Los >= 30 se multiplican por 2.
 *      - Los < 30 se multiplican por 3.
 *   3. Muestra el resultado final.
 * 
 * Aprendizaje: 
 *   - Uso de listas (List<int>)
 *   - Bucles for (normal e inverso)
 *   - Operador módulo (%) para múltiplos
 *   - Transformación de datos en listas
 *   - string.Join para mostrar listas
 */

namespace FiltrarTransformarNumeros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //programa múltiplos de 5 los que no son multiplicarlos por 2 si son mayores a 30, y si son menores a 30 multiplicarlos por 2
            List<int> list = new List<int> { 3, 10, 15, 20, 25, 30, 35, 40 };

            for (int i = list.Count - 1; i >= 0; i--)
            {
                //si el residuo es cero es múltiplo, es una regla universal para cualquier número 
                if (list[i] % 5 != 0) //si el residuo no es cero, se elimina de la lista
                {
                    list.RemoveAt(i);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] >= 30)
                {
                    list[i] *= 2;
                }
                else
                {
                    list[i] *= 3;
                }
            }
            //convertimos la lista en texto, separamos por coma
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
