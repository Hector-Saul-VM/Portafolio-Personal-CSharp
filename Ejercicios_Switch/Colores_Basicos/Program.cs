namespace Colores_Basicos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DECLARAMOS LA VARIABLE PARA PUEDA SER USADA POR DO Y POR EL WHILE ES UNA VARIABLE LOCAL SCOOPE
            string? infoColor;          
            do
            {
                Console.WriteLine("Ingresa un color (rojo, amarillo, azul");
                infoColor = Console.ReadLine();
                Console.Clear();

                if (string.IsNullOrWhiteSpace(infoColor))
                {
                    Console.WriteLine("Debes de ingresar un color \n");
                }

            } while (string.IsNullOrWhiteSpace(infoColor));


            infoColor.Trim().ToLower();

            switch(infoColor)
            {
                case "rojo":
                case "amarillo":
                case "azul":
                    Console.WriteLine($"El color {infoColor}, es un color primario");
                    break;

                default:
                    Console.WriteLine($"El color {infoColor}, (no es un color primario)");
                    break;
            }
        }
    }
}
