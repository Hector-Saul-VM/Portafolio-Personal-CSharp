namespace DivisionCorrecta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dividendo;
            double divisor;

            Console.Write("Ingresa el dividendo: ");

            while (!double.TryParse(Console.ReadLine(), out dividendo))
            {
                Console.WriteLine("Debes ingresar un número válido.");
                Console.Write("Intenta nuevamente: ");
            }

            Console.Write("Ingresa el divisor: ");

            while (!double.TryParse(Console.ReadLine(), out divisor))
            {
                Console.WriteLine("Debes ingresar un número válido.");
                Console.Write("Intenta nuevamente: ");
            }

            if (divisor != 0)
            {
                double resultado = dividendo / divisor;
                Console.WriteLine($"El resultado de la operación es: {resultado}");
            }
            else
            {
                Console.WriteLine("No es posible dividir entre cero.");
            }
        }
    }
}
