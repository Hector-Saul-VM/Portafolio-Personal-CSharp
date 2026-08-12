using RegistroEstudiantes.Logica;
using RegistroEstudiantes.Modelo;

namespace RegistroEstudiantes.UI
{
    public class Menu
    {
        private readonly GestorEstudiantes gestorEstudiantes;

        public Menu()
        {
            gestorEstudiantes = new GestorEstudiantes();
        }

        public void Iniciar()
        {
            byte opcion;

            do
            {
                Console.Clear();
                DibujarMenu();

                while (!byte.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.Write("Ingrese una opción válida: ");
                }

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        RegistrarEstudiante();
                        break;

                    case 2:
                        MostrarEstudiantes();
                        break;

                    case 3:
                        BuscarEstudiante();
                        break;

                    case 4:
                        EditarEstudiante();
                        break;

                    case 5:
                        EliminarEstudiante();
                        break;

                    case 0:
                        Console.WriteLine("Gracias por utilizar el sistema.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        Pausar();
                        break;
                }

            } while (opcion != 0);
        }

        private void DibujarMenu()
        {
            Console.Title = "Sistema Registro de Estudiantes";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================");
            Console.WriteLine("   SISTEMA REGISTRO DE ESTUDIANTES");
            Console.WriteLine("========================================");
            Console.ResetColor();

            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Mostrar estudiantes");
            Console.WriteLine("3. Buscar estudiante");
            Console.WriteLine("4. Editar estudiante");
            Console.WriteLine("5. Eliminar estudiante");
            Console.WriteLine("0. Salir");

            Console.Write("\nSeleccione una opción: ");
        }

        private void RegistrarEstudiante()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== REGISTRO DE ESTUDIANTE ===");
            Console.ResetColor();

            string nombre = LeerTextoObligatorio("Nombre: ");
            string carnet = LeerTextoObligatorio("Carnet: ");
            string carrera = LeerTextoObligatorio("Carrera: ");
            decimal nota = LeerNota();

            try
            {
                Estudiante estudiante = new Estudiante(
                    nombre,
                    carnet,
                    carrera,
                    nota);

                gestorEstudiantes.AgregarEstudiante(estudiante);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nEstudiante registrado correctamente.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            Pausar();
        }

        private void MostrarEstudiantes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== LISTADO DE ESTUDIANTES ===");
            Console.ResetColor();

            List<Estudiante> estudiantes = gestorEstudiantes.ObtenerTodos();

            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
            }
            else
            {
                foreach (Estudiante estudiante in estudiantes)
                {
                    Console.WriteLine(estudiante);
                }
            }

            Pausar();
        }

        private void BuscarEstudiante()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== BUSCAR ESTUDIANTE ===");
            Console.ResetColor();

            Console.Write("Ingrese el carnet: ");
            string carnet = Console.ReadLine()!;

            try
            {
                Estudiante? estudiante = gestorEstudiantes.BuscarPorCarnet(carnet);

                if (estudiante == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNo se encontró el estudiante.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nESTUDIANTE ENCONTRADO");
                    Console.ResetColor();

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine($"Nombre   : {estudiante.Nombre}");
                    Console.WriteLine($"Carnet   : {estudiante.Carnet}");
                    Console.WriteLine($"Carrera  : {estudiante.Carrera}");
                    Console.WriteLine($"Nota     : {estudiante.Nota:F2}");
                    Console.WriteLine($"Estado   : {estudiante.Estado}");
                    Console.WriteLine("-----------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            Pausar();
        }

        private void EditarEstudiante()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== EDITAR ESTUDIANTE ===");
            Console.ResetColor();

            Console.Write("Ingrese el carnet del estudiante: ");
            string carnet = Console.ReadLine()!;

            Estudiante? estudiante = gestorEstudiantes.BuscarPorCarnet(carnet);

            if (estudiante == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo se encontró el estudiante.");
                Console.ResetColor();

                Pausar();
                return;
            }

            Console.WriteLine("\nDatos actuales:");
            Console.WriteLine($"Nombre  : {estudiante.Nombre}");
            Console.WriteLine($"Carrera : {estudiante.Carrera}");
            Console.WriteLine($"Nota    : {estudiante.Nota:F2}");

            Console.WriteLine("\nIngrese los nuevos datos.");

            string nombre = LeerTextoObligatorio("Nombre: ");
            string carrera = LeerTextoObligatorio("Carrera: ");
            decimal nota = LeerNota();

            try
            {
                Estudiante estudianteActualizado = new Estudiante(
                    nombre,
                    carnet,
                    carrera,
                    nota);

                bool editado = gestorEstudiantes.EditarEstudiante(estudianteActualizado);

                if (editado)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nEstudiante actualizado correctamente.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNo fue posible actualizar el estudiante.");
                }

                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            Pausar();
        }
        private void EliminarEstudiante()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=== ELIMINAR ESTUDIANTE ===");
            Console.ResetColor();

            Console.Write("Ingrese el carnet del estudiante: ");
            string carnet = Console.ReadLine()!;

            try
            {
                Estudiante? estudiante = gestorEstudiantes.BuscarPorCarnet(carnet);

                if (estudiante == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nNo se encontró el estudiante.");
                    Console.ResetColor();

                    Pausar();
                    return;
                }

                Console.WriteLine("\nEstudiante encontrado:");
                Console.WriteLine($"Nombre   : {estudiante.Nombre}");
                Console.WriteLine($"Carnet   : {estudiante.Carnet}");
                Console.WriteLine($"Carrera  : {estudiante.Carrera}");
                Console.WriteLine($"Nota     : {estudiante.Nota:F2}");

                Console.Write("\n¿Está seguro de eliminar este estudiante? (S/N): ");

                ConsoleKeyInfo respuesta = Console.ReadKey();

                if (respuesta.Key == ConsoleKey.S)
                {
                    bool eliminado = gestorEstudiantes.EliminarEstudiante(carnet);

                    Console.WriteLine();

                    if (eliminado)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nEstudiante eliminado correctamente.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNo fue posible eliminar el estudiante.");
                    }

                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("\n\nOperación cancelada.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ResetColor();
            }

            Pausar();
        }

        private string LeerTextoObligatorio(string mensaje)
        {
            string texto;

            do
            {
                Console.Write(mensaje);
                texto = Console.ReadLine()!;
            }
            while (string.IsNullOrWhiteSpace(texto));

            return texto.Trim();
        }

        private decimal LeerNota()
        {
            decimal nota;

            Console.Write("Nota final: ");

            while (!decimal.TryParse(Console.ReadLine(), out nota))
            {
                Console.Write("Ingrese una nota válida: ");
            }

            return nota;
        }

        private void Pausar()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}