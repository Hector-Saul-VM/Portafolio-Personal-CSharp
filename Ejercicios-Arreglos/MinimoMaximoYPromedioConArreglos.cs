namespace PrimerEjercicio
{
    class MinimoMaximoYPromedioConArreglos
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[5];

            // Variables para guardar la suma, el número mayor y el menor
            int suma = 0;
            int mayor;
            int menor;

            // Pedimos el primer número y lo guardamos en 'primerNumero'
            Console.Write("Número 1: ");
            int primerNumero = int.Parse(Console.ReadLine());

            numeros[0] = primerNumero;      // Guardamos el primer número en la posición 0 del arreglo

            suma = primerNumero;             // Inicializamos suma, mayor y menor con el primer número
            mayor = primerNumero;
            menor = primerNumero;

            // Empezamos un ciclo desde i=1 hasta i=4 para pedir los otros 4 números
            for (int i = 1; i < 5; i++)
            {
                // Pedimos un número más y lo guardamos en 'num'
                Console.Write($"Número {i + 1}: ");
                int num = int.Parse(Console.ReadLine());

                // Guardamos el número ingresado en la posición i del arreglo, como la posición 0 ya esta ocupada lo guarda en la libre
                numeros[i] = num;

                // Sumamos el nuevo núm a la variable suma
                suma += num;

                // Comparamos si el núm es mayor que el valor actual de 'mayor' si es asi actualizamos mayor pasa a tener el valor de num
                if (num > mayor)
                    mayor = num;

                // Comparamos si el núm es menor que el valor actual de 'menor' menor pasa a tener el valor de nump
                if (num < menor)
                    menor = num;
            }
            // Calculamos el promedio como un número decimal (double)
            double promedio = (double)suma / 5;

            Console.WriteLine($"\nMayor: {mayor}");
            Console.WriteLine($"Menor: {menor}");
            Console.WriteLine($"Promedio: {promedio}");
        }
    }
}
