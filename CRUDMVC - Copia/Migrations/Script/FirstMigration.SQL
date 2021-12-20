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

CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [CPF] char(11) NOT NULL,
    [Nome] nvarchar(40) NOT NULL,
    [Email] nvarchar(40) NOT NULL,
    [Sexo] char(2) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Endereco] (
    [Id] int NOT NULL IDENTITY,
    [Rua] nvarchar(40) NOT NULL,
    [Cidade] nvarchar(40) NOT NULL,
    [Estado] nvarchar(50) NOT NULL,
    [Bairro] nvarchar(50) NOT NULL,
    [Numero] char(6) NOT NULL,
    CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Telefone] (
    [Id] int NOT NULL IDENTITY,
    [TelNumero] nvarchar(20) NOT NULL,
    [Tipo] nvarchar(10) NOT NULL,
    CONSTRAINT [PK_Telefone] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211215232424_FirstMigration', N'5.0.13');
GO

COMMIT;
GO

