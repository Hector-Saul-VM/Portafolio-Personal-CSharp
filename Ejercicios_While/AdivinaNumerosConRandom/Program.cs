namespace AdivinaNumerosConRandom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Programa que genera un número aleatorio y permite al usuario
            // intentar adivinarlo, contando la cantidad de intentos.

            Random numero = new Random();
            int aleatorio = numero.Next(0, 101); // El número aleatorio entre 0 y 100 

            int numeroPersonal;
            int intentos = 0;

            Console.WriteLine("Adivina el número entre 0 y 100. ¡Buena suerte!");

            // Bucle mientras el número adivinado no sea el correcto
            while (true)
            {
                Console.Write("Introduce un número: ");
                
                // Intentamos convertir lo ingresado a un entero 
                if (!int.TryParse(Console.ReadLine(), out numeroPersonal))
                {
                    Console.WriteLine("Debes de ingresar solo números enteros");
                    continue;
                }
                intentos++;  // Aumentar el contador de intentos

                // Comprobar si el número ingresado es mayor, menor o igual al número aleatorio
                if (numeroPersonal > aleatorio)
                {
                    Console.WriteLine("El número es más bajo.");
                }
                else if (numeroPersonal < aleatorio)
                {
                    Console.WriteLine("El número es más alto.");
                }
                else
                {
                    // Si el número es correcto, salir del bucle, un break dentro de while rompe sale del bucle
                    Console.WriteLine($"¡Correcto! Has adivinado el número en {intentos} intentos.");
                    break;
                }
            }
        }
    }
}
