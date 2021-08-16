USE master
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = '_SelfHostWebApiBC')
BEGIN
    DROP DATABASE _SelfHostWebApiBC;  
END;
CREATE DATABASE _SelfHostWebApiBC;
GO

USE _SelfHostWebApiBC;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [dbo].[Companies] (
    [Id] [bigint] NOT NULL IDENTITY,
    [Name] [varchar](100) NOT NULL,
    [EstablishmentYear] [int],
    [RowVersion] rowversion NOT NULL,
    CONSTRAINT [PK_dbo.Companies] PRIMARY KEY ([Id])
)
GO

CREATE TABLE [dbo].[Employees] (
    [Id] [bigint] NOT NULL IDENTITY,
    [FirstName] [varchar](50) NOT NULL,
    [LastName] [varchar](50) NOT NULL,
    [DateOfBirth] [datetime],
    [JobTitle] [int] NOT NULL,
    [CompanyId] [bigint] NOT NULL,
    [RowVersion] rowversion NOT NULL,
    CONSTRAINT [PK_dbo.Employees] PRIMARY KEY ([Id])
)
GO

CREATE UNIQUE INDEX [IX_Name] ON [dbo].[Companies]([Name])
CREATE INDEX [IX_EstablishmentYear] ON [dbo].[Companies]([EstablishmentYear])
CREATE INDEX [IX_FirstName_LastName] ON [dbo].[Employees]([FirstName], [LastName])
CREATE INDEX [IX_DateOfBirth] ON [dbo].[Employees]([DateOfBirth])
CREATE INDEX [IX_JobTitle] ON [dbo].[Employees]([JobTitle])
CREATE INDEX [IX_CompanyId] ON [dbo].[Employees]([CompanyId])

ALTER TABLE [dbo].[Employees] ADD CONSTRAINT [FK_dbo.Employees_dbo.Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id]) ON DELETE CASCADE

CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
GO

COMMIT;
GO