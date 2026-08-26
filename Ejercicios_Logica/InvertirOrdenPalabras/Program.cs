namespace InvertirOrdenPalabras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola ingresa una frase:");
            string frase = Console.ReadLine();

            // Separar la frase en palabras
            string[] palabras = frase.Split(' ');

            // Recorrer el arreglo al revés
            for (int i = palabras.Length - 1; i >= 0; i--)
            {
                Console.Write(palabras[i]);

                // Para evitar espacio al final es decir solo colocamos espacio si i no es 0 porque si no lo hacemos al imprimir empezaria con un espacio 
                if (i != 0)
                {
                    Console.Write(" ");
                }
            }
        }
    }
}
