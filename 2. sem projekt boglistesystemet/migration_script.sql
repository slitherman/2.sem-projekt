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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE TABLE [Boghandlere] (
        [BoghandlerId] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [Address] nvarchar(50) NOT NULL,
        [PostalCode] int NOT NULL,
        [password] int NOT NULL,
        CONSTRAINT [PK_Boghandlere] PRIMARY KEY ([BoghandlerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE TABLE [Koordinatorer] (
        [KoordinatorId] int NOT NULL IDENTITY,
        [Password] int NOT NULL,
        CONSTRAINT [PK_Koordinatorer] PRIMARY KEY ([KoordinatorId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE TABLE [Fag] (
        [FagId] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [KoordinatorId] int NULL,
        CONSTRAINT [PK_Fag] PRIMARY KEY ([FagId]),
        CONSTRAINT [FK_Fag_Koordinatorer_KoordinatorId] FOREIGN KEY ([KoordinatorId]) REFERENCES [Koordinatorer] ([KoordinatorId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE TABLE [Hold] (
        [HoldId] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [KoordinatorId] int NULL,
        CONSTRAINT [PK_Hold] PRIMARY KEY ([HoldId]),
        CONSTRAINT [FK_Hold_Koordinatorer_KoordinatorId] FOREIGN KEY ([KoordinatorId]) REFERENCES [Koordinatorer] ([KoordinatorId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE TABLE [Uddannelser] (
        [UddannelseId] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [KoordinatorId] int NULL,
        CONSTRAINT [PK_Uddannelser] PRIMARY KEY ([UddannelseId]),
        CONSTRAINT [FK_Uddannelser_Koordinatorer_KoordinatorId] FOREIGN KEY ([KoordinatorId]) REFERENCES [Koordinatorer] ([KoordinatorId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE TABLE [Undervisere] (
        [UnderviserId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(100) NOT NULL,
        [LastName] nvarchar(100) NOT NULL,
        [Initials] nvarchar(10) NULL,
        [KoordinatorId] int NULL,
        CONSTRAINT [PK_Undervisere] PRIMARY KEY ([UnderviserId]),
        CONSTRAINT [FK_Undervisere_Koordinatorer_KoordinatorId] FOREIGN KEY ([KoordinatorId]) REFERENCES [Koordinatorer] ([KoordinatorId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE TABLE [Semestre] (
        [SemesterId] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [KoordinatorId] int NULL,
        [UddannelserUddannelseId] int NULL,
        CONSTRAINT [PK_Semestre] PRIMARY KEY ([SemesterId]),
        CONSTRAINT [FK_Semestre_Koordinatorer_KoordinatorId] FOREIGN KEY ([KoordinatorId]) REFERENCES [Koordinatorer] ([KoordinatorId]),
        CONSTRAINT [FK_Semestre_Uddannelser_UddannelserUddannelseId] FOREIGN KEY ([UddannelserUddannelseId]) REFERENCES [Uddannelser] ([UddannelseId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE TABLE [Bøger] (
        [BogId] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [Year] datetime2 NOT NULL,
        [Author] nvarchar(50) NOT NULL,
        [ISBN] int NULL,
        [BoghandlerId] int NULL,
        [UnderviserId] int NULL,
        CONSTRAINT [PK_Bøger] PRIMARY KEY ([BogId]),
        CONSTRAINT [FK_Bøger_Boghandlere_BoghandlerId] FOREIGN KEY ([BoghandlerId]) REFERENCES [Boghandlere] ([BoghandlerId]),
        CONSTRAINT [FK_Bøger_Undervisere_UnderviserId] FOREIGN KEY ([UnderviserId]) REFERENCES [Undervisere] ([UnderviserId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE TABLE [FagUnderviser] (
        [FagId] int NOT NULL,
        [UnderviserId] int NOT NULL,
        CONSTRAINT [PK_FagUnderviser] PRIMARY KEY ([FagId], [UnderviserId]),
        CONSTRAINT [FK_FagUnderviser_Fag_FagId] FOREIGN KEY ([FagId]) REFERENCES [Fag] ([FagId]) ON DELETE CASCADE,
        CONSTRAINT [FK_FagUnderviser_Undervisere_UnderviserId] FOREIGN KEY ([UnderviserId]) REFERENCES [Undervisere] ([UnderviserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE TABLE [HoldSemestre] (
        [HoldId] int NOT NULL,
        [semestreSemesterId] int NOT NULL,
        CONSTRAINT [PK_HoldSemestre] PRIMARY KEY ([HoldId], [semestreSemesterId]),
        CONSTRAINT [FK_HoldSemestre_Hold_HoldId] FOREIGN KEY ([HoldId]) REFERENCES [Hold] ([HoldId]) ON DELETE CASCADE,
        CONSTRAINT [FK_HoldSemestre_Semestre_semestreSemesterId] FOREIGN KEY ([semestreSemesterId]) REFERENCES [Semestre] ([SemesterId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE INDEX [IX_Bøger_BoghandlerId] ON [Bøger] ([BoghandlerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE INDEX [IX_Bøger_UnderviserId] ON [Bøger] ([UnderviserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE INDEX [IX_Fag_KoordinatorId] ON [Fag] ([KoordinatorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE INDEX [IX_FagUnderviser_UnderviserId] ON [FagUnderviser] ([UnderviserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE INDEX [IX_Hold_KoordinatorId] ON [Hold] ([KoordinatorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE INDEX [IX_HoldSemestre_semestreSemesterId] ON [HoldSemestre] ([semestreSemesterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE INDEX [IX_Semestre_KoordinatorId] ON [Semestre] ([KoordinatorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE INDEX [IX_Semestre_UddannelserUddannelseId] ON [Semestre] ([UddannelserUddannelseId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE INDEX [IX_Uddannelser_KoordinatorId] ON [Uddannelser] ([KoordinatorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    CREATE INDEX [IX_Undervisere_KoordinatorId] ON [Undervisere] ([KoordinatorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130175225_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221130175225_Initial', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221130184520_mssql.azure_migration_187')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221130184520_mssql.azure_migration_187', N'7.0.0');
END;
GO

COMMIT;
GO

