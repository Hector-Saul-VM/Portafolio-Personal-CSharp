using RegistroEstudiantes.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RegistroEstudiantes.Logica
{
    public class ArchivoBinario
    {
        private readonly string _rutaArchivo;

        public ArchivoBinario(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
                throw new ArgumentException("La ruta del archivo es obligatoria.", nameof(rutaArchivo));

            _rutaArchivo = rutaArchivo;

            CrearCarpetaSiNoExiste();
        }

        //==========================
        // CREATE
        //==========================

        public void Guardar(Estudiante estudiante)
        {
            ArgumentNullException.ThrowIfNull(estudiante);

            using BinaryWriter escritor = new BinaryWriter(
                File.Open(_rutaArchivo, FileMode.Append));

            escritor.Write(estudiante.Nombre);
            escritor.Write(estudiante.Carnet);
            escritor.Write(estudiante.Carrera);
            escritor.Write(estudiante.Nota);
        }

        //==========================
        // READ
        //==========================

        public List<Estudiante> ObtenerTodos()
        {
            List<Estudiante> estudiantes = new();

            if (!File.Exists(_rutaArchivo))
                return estudiantes;

            using BinaryReader lector = new BinaryReader(
                File.Open(_rutaArchivo, FileMode.Open));

            while (lector.BaseStream.Position < lector.BaseStream.Length)
            {
                estudiantes.Add(LeerEstudiante(lector));
            }

            return estudiantes;
        }

        public Estudiante? BuscarPorCarnet(string carnet)
        {
            return ObtenerTodos()
                .FirstOrDefault(e =>
                    e.Carnet.Equals(carnet, StringComparison.OrdinalIgnoreCase));
        }

        //==========================
        // UPDATE
        //==========================

        public bool Editar(Estudiante estudianteActualizado)
        {
            List<Estudiante> estudiantes = ObtenerTodos();

            int indice = estudiantes.FindIndex(e =>
                e.Carnet.Equals(
                    estudianteActualizado.Carnet,
                    StringComparison.OrdinalIgnoreCase));

            if (indice == -1)
                return false;

            estudiantes[indice] = estudianteActualizado;

            SobrescribirArchivo(estudiantes);

            return true;
        }

        //==========================
        // DELETE
        //==========================

        public bool Eliminar(string carnet)
        {
            List<Estudiante> estudiantes = ObtenerTodos();

            bool eliminado = estudiantes.RemoveAll(e =>
                e.Carnet.Equals(
                    carnet,
                    StringComparison.OrdinalIgnoreCase)) > 0;

            if (eliminado)
            {
                SobrescribirArchivo(estudiantes);
            }

            return eliminado;
        }

        //==========================
        // VALIDACIÓN
        //==========================

        public bool ExisteCarnet(string carnet)
        {
            return BuscarPorCarnet(carnet) != null;
        }

        //==========================
        // MÉTODOS PRIVADOS
        //==========================

        private void CrearCarpetaSiNoExiste()
        {
            string? carpeta = Path.GetDirectoryName(_rutaArchivo);

            if (!string.IsNullOrEmpty(carpeta) && !Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }
        }

        private void SobrescribirArchivo(List<Estudiante> estudiantes)
        {
            using BinaryWriter escritor = new BinaryWriter(
                File.Open(_rutaArchivo, FileMode.Create));

            foreach (Estudiante estudiante in estudiantes)
            {
                escritor.Write(estudiante.Nombre);
                escritor.Write(estudiante.Carnet);
                escritor.Write(estudiante.Carrera);
                escritor.Write(estudiante.Nota);
            }
        }

        private Estudiante LeerEstudiante(BinaryReader lector)
        {
            string nombre = lector.ReadString();
            string carnet = lector.ReadString();
            string carrera = lector.ReadString();
            decimal nota = lector.ReadDecimal();

            return new Estudiante(
                nombre,
                carnet,
                carrera,
                nota);
        }
    }
}