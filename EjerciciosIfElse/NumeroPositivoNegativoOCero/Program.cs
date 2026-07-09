namespace NumeroPositivoNegativoOCero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("ingresa un numero por favor: ");
            int numero;

            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Debes ingresar un número entero");
                Console.Write("Intenta nuevamente: ");
            }

            if (numero > 0)
            {
                Console.WriteLine("El número ingresado es positivo.");
            }

            else if (numero < 0)
            {
                Console.WriteLine("El número ingresado es negativo.");
            }

            //después de un if y un else if, else nunca lleva una condición
            else
            {
                Console.WriteLine("El número ingresado es cero.");
            }

            Console.ReadKey();
        }
    }
}
