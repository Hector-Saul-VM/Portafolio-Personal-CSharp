using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEmpleadosAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaContratacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    HoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oficina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoEmpleado = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    NumeroCaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManejaEfectivo = table.Column<bool>(type: "bit", nullable: true),
                    PuedePagarCheques = table.Column<bool>(type: "bit", nullable: true),
                    PuedeHacerDepositos = table.Column<bool>(type: "bit", nullable: true),
                    AgenciaAsignada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroEmpleadosACargo = table.Column<int>(type: "int", nullable: true),
                    AccesoADatosSensibles = table.Column<bool>(type: "bit", nullable: true),
                    LimiteCreditoAutorizable = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NumeroClientesAsignados = table.Column<int>(type: "int", nullable: true),
                    PuedeAbrirCuentas = table.Column<bool>(type: "bit", nullable: true),
                    PuedeVenderSeguros = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalExterno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaExterna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    TipoPersonal = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    DepartamentoAsignado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Turno = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalExterno", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "PersonalExterno");
        }
    }
}
