namespace Solicitud_Colores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable local declarada fuera del do para que pueda utilizarse
            // tanto dentro del do como en la condición del while.
            string? infoColor;
            do
            {
                Console.WriteLine("Ingresa un color (rojo, amarillo, azul):");
                infoColor = Console.ReadLine();

                // Si el usuario no escribe nada, se muestra un mensaje
                // y el ciclo volverá a solicitar el dato.
                if (string.IsNullOrWhiteSpace(infoColor))
                {
                    Console.WriteLine("Debes de ingresar un color");
                    Console.ReadKey();
                    Console.Clear();
                }

                // El ciclo termina cuando el usuario ingresa un valor válido.
            } while (string.IsNullOrWhiteSpace(infoColor));

            //guardamos el resultado en la variable porque los métodos no modifican la variable original
            infoColor = infoColor.Trim().ToLower();

            switch (infoColor)
            {
                case "rojo":
                case "amarillo":
                case "azul":
                    Console.WriteLine($"El color {infoColor} es un color primario");
                    break;

                default:
                    Console.WriteLine($"El color {infoColor} no es un color primario");
                    break;
            }
        }
    }
}
