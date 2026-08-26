namespace ContarPalabrasRepetidasBucles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola ingresa una frase:");
            string frase = Console.ReadLine().ToLower();

            string[] palabras = frase.Split(' ');

            for (int i = 0; i < palabras.Length; i++)
            {
                int contador = 0;
                bool yaContada = false;

                // Verificar si ya se contó antes es decir si la palabra ya apareció antes
                for (int k = 0; k < i; k++)
                {
                    if (palabras[i] == palabras[k])
                    {
                        yaContada = true;
                        break;
                    }
                }

                // si la palabra ya se conto se salta y regresa a la otra palabra a evaluar
                if (yaContada)
                {
                    continue;
                }

                // Contar repeticiones
                for (int j = 0; j < palabras.Length; j++)
                {
                    if (palabras[i] == palabras[j])
                    {
                        contador++;
                    }
                }

                Console.WriteLine($"{palabras[i]}: {contador}");
            }
        }
    }
}
