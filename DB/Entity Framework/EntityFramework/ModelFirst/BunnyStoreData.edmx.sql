
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/28/2014 14:05:15
-- Generated from EDMX file: C:\Users\Boycho\Documents\Visual Studio 2013\Projects\DB\Entity Framework\EntityFramework\ModelFirst\BunnyStoreData.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BunnyStore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bunnies'
CREATE TABLE [dbo].[Bunnies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Color] nvarchar(max)  NOT NULL,
    [Age] smallint  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Spaceship_Id] int  NOT NULL
);
GO

-- Creating table 'Spaceships'
CREATE TABLE [dbo].[Spaceships] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Model] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bunnies'
ALTER TABLE [dbo].[Bunnies]
ADD CONSTRAINT [PK_Bunnies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Spaceships'
ALTER TABLE [dbo].[Spaceships]
ADD CONSTRAINT [PK_Spaceships]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Spaceship_Id] in table 'Bunnies'
ALTER TABLE [dbo].[Bunnies]
ADD CONSTRAINT [FK_SpaceshipBunny]
    FOREIGN KEY ([Spaceship_Id])
    REFERENCES [dbo].[Spaceships]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SpaceshipBunny'
CREATE INDEX [IX_FK_SpaceshipBunny]
ON [dbo].[Bunnies]
    ([Spaceship_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------