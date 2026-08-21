/*
Héctor Vega
Fecha: 21/08/2026
Ejercicio: Paréntesis Balanceados (Valid Parentheses)
Verifica si una cadena de paréntesis está correctamente balanceada
usando una estructura tipo Stack (pila). Clásico de pruebas técnicas.
*/
namespace ParentesisBalanceados
{
    internal class Program
    {
        public static void Main()
        {
            var tests = new[] { "()", "(())", "((()))", "(()", ")(", "", "()(())", "H" };
            foreach (var t in tests)
            {
                Console.WriteLine($"{t} -> {EsBalanceadaNoVacia(t)}");
            }
        }
        // Devuelve true si la cadena está correctamente balanceada y n>0 (al menos un par)
        public static bool EsBalanceadaNoVacia(string s)
        {
            // Creamos una nueva pila vacía la cual puede almacenar objetos de tipo char
            var stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(') stack.Push(c);
                else if (c == ')')
                {
                    if (stack.Count == 0) return false;
                    stack.Pop();
                }
                else
                {
                    // si hay otros símbolos, opcionalmente rechazamos
                    return false;
                }
            }
            // pila vacía y se leyó al menos un par
            return stack.Count == 0 && s.Length > 0;
        }
    }
}
