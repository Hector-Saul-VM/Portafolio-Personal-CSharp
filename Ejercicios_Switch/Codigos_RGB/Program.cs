namespace Codigos_RGB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opColor = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ DE COLORES RGB ===");
                Console.WriteLine("1. Rojo (Red)");
                Console.WriteLine("2. Verde (Green)");
                Console.WriteLine("3. Azul (Blue)");
                Console.WriteLine("===========================");
                Console.Write("Ingresa el número del color que deseas: ");

                int.TryParse(Console.ReadLine(), out opColor);

                // Si el usuario pone un número que no es 1, 2 ni 3, le avisa y repite
                if (opColor < 1 || opColor > 3)
                {
                    Console.WriteLine("\nOpción inválida. Presiona cualquier tecla para intentar de nuevo...");
                    Console.ReadKey();
                }
            }
            while (opColor <1 || opColor > 3); //se repite si esta fuera del rango 1 a 3
                
            switch (opColor)
            {
                case 1:                                         
                    Console.WriteLine("el código RGB para el color {0} es: 255,0,0 ", opColor);
                    break;
                case 2:
                    Console.WriteLine("el código RGB para el color {0} es: 0,255,0 ", opColor);
                    break;
                case 3:
                    Console.WriteLine("el codigo RGB para el color {0} es: 0,0,255", opColor);
                    break;
                default:
                    Console.WriteLine("el color {0}, que usted escogio no tiene codigo RGB intenta de nuevo:",opColor);
                    break;
            }
            Console.ReadKey();
        }
    }
}

