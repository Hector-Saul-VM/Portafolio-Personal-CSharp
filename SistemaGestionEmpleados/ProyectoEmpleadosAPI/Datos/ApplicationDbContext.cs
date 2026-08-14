using Microsoft.EntityFrameworkCore;
using ProyectoEmpleadosAPI.Modelos;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProyectoEmpleadosAPI.Datos
{
    public class ApplicationDbContext : DbContext
    {
        // 1️⃣ Constructor (obligatorio)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // 2️⃣ Tablas (DbSet) - FUERA del constructor
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<GerenteAgencia> GerentesAgencia { get; set; }
        public DbSet<GestorCreditos> GestoresCreditos { get; set; }
        public DbSet<Cajero> Cajeros { get; set; }
        public DbSet<PersonalExterno> PersonalExterno { get; set; }
        public DbSet<Conserje> Conserjes { get; set; }

        // 3️⃣ Configuración de las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Empleado y sus hijos (TPH)
            modelBuilder.Entity<Empleado>()
                .ToTable("Empleados")
                .HasDiscriminator<string>("TipoEmpleado")
                .HasValue<GerenteAgencia>("Gerente")
                .HasValue<GestorCreditos>("Gestor")
                .HasValue<Cajero>("Cajero");

            // Configuración de PersonalExterno y sus hijos (TPH)
            modelBuilder.Entity<PersonalExterno>()
                .ToTable("PersonalExterno")
                .HasDiscriminator<string>("TipoPersonal")
                .HasValue<Conserje>("Conserje");
        }
    }
}