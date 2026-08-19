IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Empleados] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Apellido] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Telefono] nvarchar(max) NULL,
    [FechaContratacion] datetime2 NOT NULL,
    [Salario] decimal(18,2) NOT NULL,
    [EstaActivo] bit NOT NULL,
    [HoraEntrada] datetime2 NOT NULL,
    [HoraSalida] datetime2 NOT NULL,
    [Departamento] nvarchar(max) NULL,
    [Oficina] nvarchar(max) NULL,
    [TipoEmpleado] nvarchar(8) NOT NULL,
    [NumeroCaja] nvarchar(max) NULL,
    [ManejaEfectivo] bit NULL,
    [PuedePagarCheques] bit NULL,
    [PuedeHacerDepositos] bit NULL,
    [AgenciaAsignada] nvarchar(max) NULL,
    [NumeroEmpleadosACargo] int NULL,
    [AccesoADatosSensibles] bit NULL,
    [LimiteCreditoAutorizable] decimal(18,2) NULL,
    [NumeroClientesAsignados] int NULL,
    [PuedeAbrirCuentas] bit NULL,
    [PuedeVenderSeguros] bit NULL,
    CONSTRAINT [PK_Empleados] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PersonalExterno] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Apellido] nvarchar(max) NOT NULL,
    [EmpresaExterna] nvarchar(max) NULL,
    [HoraEntrada] datetime2 NOT NULL,
    [HoraSalida] datetime2 NOT NULL,
    [EstaActivo] bit NOT NULL,
    [TipoPersonal] nvarchar(21) NOT NULL,
    [DepartamentoAsignado] nvarchar(max) NULL,
    [Turno] nvarchar(max) NULL,
    CONSTRAINT [PK_PersonalExterno] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260819205459_Inicial', N'8.0.11');
GO

COMMIT;
GO

