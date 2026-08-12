using System;

namespace RegistroEstudiantes.Modelo
{
    public class Estudiante
    {
        // Campos privados
        private string nombre;
        private string carnet;
        private string carrera;
        private decimal nota;

        // Propiedades
        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre es obligatorio.", nameof(value));

                nombre = value.Trim();
            }
        }

        public string Carnet
        {
            get => carnet;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El carnet es obligatorio.", nameof(value));

                carnet = value.Trim();
            }
        }

        public string Carrera
        {
            get => carrera;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La carrera es obligatoria.", nameof(value));

                carrera = value.Trim();
            }
        }

        public decimal Nota
        {
            get => nota;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "La nota debe estar entre 0 y 100.");

                nota = value;
            }
        }

        // Propiedades calculadas
        public bool Aprobo => Nota >= 61;

        public string Estado => Aprobo ? "Aprobado" : "Reprobado";

        // Constructor
        public Estudiante(string nombre, string carnet, string carrera, decimal nota)
        {
            Nombre = nombre;
            Carnet = carnet;
            Carrera = carrera;
            Nota = nota;
        }

        public override string ToString()
        {
            return $"{Carnet} | {Nombre} | {Carrera} | {Nota:F2} | {Estado}";
        }
    }
}