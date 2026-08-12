using RegistroEstudiantes.Modelo;
using System;
using System.Collections.Generic;

namespace RegistroEstudiantes.Logica
{
    public class GestorEstudiantes
    {
        private readonly ArchivoBinario archivoBinario;

        public GestorEstudiantes()
        {
            archivoBinario = new ArchivoBinario(@"C:\UMG\estudiantes.bin");
        }

        /// <summary>
        /// Recibe un objeto de tipo Estudiante y lo guarda.
        /// </summary>
        public void AgregarEstudiante(Estudiante estudiante)
        {
            ArgumentNullException.ThrowIfNull(estudiante);

            archivoBinario.Guardar(estudiante);
        }

      

        /// <summary>
        /// Obtiene todos los estudiantes.
        /// </summary>
        public List<Estudiante> ObtenerTodos()
        {
            return archivoBinario.ObtenerTodos();
        }

        /// <summary>
        /// Busca un estudiante por su carnet.
        /// </summary>
        public Estudiante? BuscarPorCarnet(string carnet)
        {
            if (string.IsNullOrWhiteSpace(carnet))
                throw new ArgumentException("El carnet es obligatorio.", nameof(carnet));
            return archivoBinario.BuscarPorCarnet(carnet);
        }

        /// <summary>
        /// Edita un estudiante existente.
        /// </summary>
        public bool EditarEstudiante(Estudiante estudiante)
        {
            if (estudiante == null)
                throw new ArgumentNullException(nameof(estudiante));

            return archivoBinario.Editar(estudiante);
        }

        /// <summary>
        /// Elimina un estudiante por carnet.
        /// </summary>
        public bool EliminarEstudiante(string carnet)
        {
            if (string.IsNullOrWhiteSpace(carnet))
                throw new ArgumentException("El carnet es obligatorio.", nameof(carnet));

            return archivoBinario.Eliminar(carnet);
        }

        /// <summary>
        /// Verifica si un carnet ya existe.
        /// </summary>
        public bool ExisteCarnet(string carnet)
        {
            return archivoBinario.ExisteCarnet(carnet);
        }
    }
}