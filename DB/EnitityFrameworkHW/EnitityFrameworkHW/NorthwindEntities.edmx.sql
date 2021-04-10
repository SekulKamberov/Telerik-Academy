
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/17/2015 15:07:35
-- Generated from EDMX file: C:\Users\bobby\Documents\Visual Studio 2013\Projects\C#\DB\EnitityFrameworkHW\EnitityFrameworkHW\NorthwindEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Northwind];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerCustomerDemo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerCustomerDemo] DROP CONSTRAINT [FK_CustomerCustomerDemo];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerCustomerDemo_Customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerCustomerDemo] DROP CONSTRAINT [FK_CustomerCustomerDemo_Customers];
GO
IF OBJECT_ID(N'[dbo].[FK_Employees_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeTerritories_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeTerritories] DROP CONSTRAINT [FK_EmployeeTerritories_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeTerritories_Territories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeTerritories] DROP CONSTRAINT [FK_EmployeeTerritories_Territories];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Details_Orders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT [FK_Order_Details_Orders];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Details_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT [FK_Order_Details_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Customers];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Shippers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Shippers];
GO
IF OBJECT_ID(N'[dbo].[FK_Products_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_Products_Suppliers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Suppliers];
GO
IF OBJECT_ID(N'[dbo].[FK_Territories_Region]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Territories] DROP CONSTRAINT [FK_Territories_Region];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[CustomerCustomerDemo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerCustomerDemo];
GO
IF OBJECT_ID(N'[dbo].[CustomerDemographics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerDemographics];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[EmployeeTerritories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeTerritories];
GO
IF OBJECT_ID(N'[dbo].[Order Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order Details];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Region]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Region];
GO
IF OBJECT_ID(N'[dbo].[Shippers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shippers];
GO
IF OBJECT_ID(N'[dbo].[Suppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Suppliers];
GO
IF OBJECT_ID(N'[dbo].[Territories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Territories];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(15)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Picture] varbinary(max)  NULL
);
GO

-- Creating table 'CustomerDemographics'
CREATE TABLE [dbo].[CustomerDemographics] (
    [CustomerTypeID] nchar(10)  NOT NULL,
    [CustomerDesc] nvarchar(max)  NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerID] nchar(5)  NOT NULL,
    [CompanyName] nvarchar(40)  NOT NULL,
    [ContactName] nvarchar(30)  NULL,
    [ContactTitle] nvarchar(30)  NULL,
    [Address] nvarchar(60)  NULL,
    [City] nvarchar(15)  NULL,
    [Region] nvarchar(15)  NULL,
    [PostalCode] nvarchar(10)  NULL,
    [Country] nvarchar(15)  NULL,
    [Phone] nvarchar(24)  NULL,
    [Fax] nvarchar(24)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [LastName] nvarchar(20)  NOT NULL,
    [FirstName] nvarchar(10)  NOT NULL,
    [Title] nvarchar(30)  NULL,
    [TitleOfCourtesy] nvarchar(25)  NULL,
    [BirthDate] datetime  NULL,
    [HireDate] datetime  NULL,
    [Address] nvarchar(60)  NULL,
    [City] nvarchar(15)  NULL,
    [Region] nvarchar(15)  NULL,
    [PostalCode] nvarchar(10)  NULL,
    [Country] nvarchar(15)  NULL,
    [HomePhone] nvarchar(24)  NULL,
    [Extension] nvarchar(4)  NULL,
    [Photo] varbinary(max)  NULL,
    [Notes] nvarchar(max)  NULL,
    [ReportsTo] int  NULL,
    [PhotoPath] nvarchar(255)  NULL
);
GO

-- Creating table 'Order_Details'
CREATE TABLE [dbo].[Order_Details] (
    [OrderID] int  NOT NULL,
    [ProductID] int  NOT NULL,
    [UnitPrice] decimal(19,4)  NOT NULL,
    [Quantity] smallint  NOT NULL,
    [Discount] real  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [CustomerID] nchar(5)  NULL,
    [EmployeeID] int  NULL,
    [OrderDate] datetime  NULL,
    [RequiredDate] datetime  NULL,
    [ShippedDate] datetime  NULL,
    [ShipVia] int  NULL,
    [Freight] decimal(19,4)  NULL,
    [ShipName] nvarchar(40)  NULL,
    [ShipAddress] nvarchar(60)  NULL,
    [ShipCity] nvarchar(15)  NULL,
    [ShipRegion] nvarchar(15)  NULL,
    [ShipPostalCode] nvarchar(10)  NULL,
    [ShipCountry] nvarchar(15)  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(40)  NOT NULL,
    [SupplierID] int  NULL,
    [CategoryID] int  NULL,
    [QuantityPerUnit] nvarchar(20)  NULL,
    [UnitPrice] decimal(19,4)  NULL,
    [UnitsInStock] smallint  NULL,
    [UnitsOnOrder] smallint  NULL,
    [ReorderLevel] smallint  NULL,
    [Discontinued] bit  NOT NULL
);
GO

-- Creating table 'Regions'
CREATE TABLE [dbo].[Regions] (
    [RegionID] int  NOT NULL,
    [RegionDescription] nchar(50)  NOT NULL
);
GO

-- Creating table 'Shippers'
CREATE TABLE [dbo].[Shippers] (
    [ShipperID] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(40)  NOT NULL,
    [Phone] nvarchar(24)  NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [SupplierID] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(40)  NOT NULL,
    [ContactName] nvarchar(30)  NULL,
    [ContactTitle] nvarchar(30)  NULL,
    [Address] nvarchar(60)  NULL,
    [City] nvarchar(15)  NULL,
    [Region] nvarchar(15)  NULL,
    [PostalCode] nvarchar(10)  NULL,
    [Country] nvarchar(15)  NULL,
    [Phone] nvarchar(24)  NULL,
    [Fax] nvarchar(24)  NULL,
    [HomePage] nvarchar(max)  NULL
);
GO

-- Creating table 'Territories'
CREATE TABLE [dbo].[Territories] (
    [TerritoryID] nvarchar(20)  NOT NULL,
    [TerritoryDescription] nchar(50)  NOT NULL,
    [RegionID] int  NOT NULL
);
GO

-- Creating table 'Employees_SubEmployee'
CREATE TABLE [dbo].[Employees_SubEmployee] (
    [EmployeeID] int  NOT NULL
);
GO

-- Creating table 'CustomerCustomerDemo'
CREATE TABLE [dbo].[CustomerCustomerDemo] (
    [CustomerDemographics_CustomerTypeID] nchar(10)  NOT NULL,
    [Customers_CustomerID] nchar(5)  NOT NULL
);
GO

-- Creating table 'EmployeeTerritories'
CREATE TABLE [dbo].[EmployeeTerritories] (
    [Employees_EmployeeID] int  NOT NULL,
    [Territories_TerritoryID] nvarchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CategoryID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [CustomerTypeID] in table 'CustomerDemographics'
ALTER TABLE [dbo].[CustomerDemographics]
ADD CONSTRAINT [PK_CustomerDemographics]
    PRIMARY KEY CLUSTERED ([CustomerTypeID] ASC);
GO

-- Creating primary key on [CustomerID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [OrderID], [ProductID] in table 'Order_Details'
ALTER TABLE [dbo].[Order_Details]
ADD CONSTRAINT [PK_Order_Details]
    PRIMARY KEY CLUSTERED ([OrderID], [ProductID] ASC);
GO

-- Creating primary key on [OrderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [RegionID] in table 'Regions'
ALTER TABLE [dbo].[Regions]
ADD CONSTRAINT [PK_Regions]
    PRIMARY KEY CLUSTERED ([RegionID] ASC);
GO

-- Creating primary key on [ShipperID] in table 'Shippers'
ALTER TABLE [dbo].[Shippers]
ADD CONSTRAINT [PK_Shippers]
    PRIMARY KEY CLUSTERED ([ShipperID] ASC);
GO

-- Creating primary key on [SupplierID] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([SupplierID] ASC);
GO

-- Creating primary key on [TerritoryID] in table 'Territories'
ALTER TABLE [dbo].[Territories]
ADD CONSTRAINT [PK_Territories]
    PRIMARY KEY CLUSTERED ([TerritoryID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees_SubEmployee'
ALTER TABLE [dbo].[Employees_SubEmployee]
ADD CONSTRAINT [PK_Employees_SubEmployee]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [CustomerDemographics_CustomerTypeID], [Customers_CustomerID] in table 'CustomerCustomerDemo'
ALTER TABLE [dbo].[CustomerCustomerDemo]
ADD CONSTRAINT [PK_CustomerCustomerDemo]
    PRIMARY KEY CLUSTERED ([CustomerDemographics_CustomerTypeID], [Customers_CustomerID] ASC);
GO

-- Creating primary key on [Employees_EmployeeID], [Territories_TerritoryID] in table 'EmployeeTerritories'
ALTER TABLE [dbo].[EmployeeTerritories]
ADD CONSTRAINT [PK_EmployeeTerritories]
    PRIMARY KEY CLUSTERED ([Employees_EmployeeID], [Territories_TerritoryID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_Categories]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Products_Categories'
CREATE INDEX [IX_FK_Products_Categories]
ON [dbo].[Products]
    ([CategoryID]);
GO

-- Creating foreign key on [CustomerID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Customers]
    FOREIGN KEY ([CustomerID])
    REFERENCES [dbo].[Customers]
        ([CustomerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Customers'
CREATE INDEX [IX_FK_Orders_Customers]
ON [dbo].[Orders]
    ([CustomerID]);
GO

-- Creating foreign key on [ReportsTo] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employees_Employees]
    FOREIGN KEY ([ReportsTo])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employees_Employees'
CREATE INDEX [IX_FK_Employees_Employees]
ON [dbo].[Employees]
    ([ReportsTo]);
GO

-- Creating foreign key on [EmployeeID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Employees]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Employees'
CREATE INDEX [IX_FK_Orders_Employees]
ON [dbo].[Orders]
    ([EmployeeID]);
GO

-- Creating foreign key on [OrderID] in table 'Order_Details'
ALTER TABLE [dbo].[Order_Details]
ADD CONSTRAINT [FK_Order_Details_Orders]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Orders]
        ([OrderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductID] in table 'Order_Details'
ALTER TABLE [dbo].[Order_Details]
ADD CONSTRAINT [FK_Order_Details_Products]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Details_Products'
CREATE INDEX [IX_FK_Order_Details_Products]
ON [dbo].[Order_Details]
    ([ProductID]);
GO

-- Creating foreign key on [ShipVia] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Shippers]
    FOREIGN KEY ([ShipVia])
    REFERENCES [dbo].[Shippers]
        ([ShipperID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Shippers'
CREATE INDEX [IX_FK_Orders_Shippers]
ON [dbo].[Orders]
    ([ShipVia]);
GO

-- Creating foreign key on [SupplierID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_Suppliers]
    FOREIGN KEY ([SupplierID])
    REFERENCES [dbo].[Suppliers]
        ([SupplierID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Products_Suppliers'
CREATE INDEX [IX_FK_Products_Suppliers]
ON [dbo].[Products]
    ([SupplierID]);
GO

-- Creating foreign key on [RegionID] in table 'Territories'
ALTER TABLE [dbo].[Territories]
ADD CONSTRAINT [FK_Territories_Region]
    FOREIGN KEY ([RegionID])
    REFERENCES [dbo].[Regions]
        ([RegionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Territories_Region'
CREATE INDEX [IX_FK_Territories_Region]
ON [dbo].[Territories]
    ([RegionID]);
GO

-- Creating foreign key on [CustomerDemographics_CustomerTypeID] in table 'CustomerCustomerDemo'
ALTER TABLE [dbo].[CustomerCustomerDemo]
ADD CONSTRAINT [FK_CustomerCustomerDemo_CustomerDemographics]
    FOREIGN KEY ([CustomerDemographics_CustomerTypeID])
    REFERENCES [dbo].[CustomerDemographics]
        ([CustomerTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Customers_CustomerID] in table 'CustomerCustomerDemo'
ALTER TABLE [dbo].[CustomerCustomerDemo]
ADD CONSTRAINT [FK_CustomerCustomerDemo_Customers]
    FOREIGN KEY ([Customers_CustomerID])
    REFERENCES [dbo].[Customers]
        ([CustomerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerCustomerDemo_Customers'
CREATE INDEX [IX_FK_CustomerCustomerDemo_Customers]
ON [dbo].[CustomerCustomerDemo]
    ([Customers_CustomerID]);
GO

-- Creating foreign key on [Employees_EmployeeID] in table 'EmployeeTerritories'
ALTER TABLE [dbo].[EmployeeTerritories]
ADD CONSTRAINT [FK_EmployeeTerritories_Employees]
    FOREIGN KEY ([Employees_EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Territories_TerritoryID] in table 'EmployeeTerritories'
ALTER TABLE [dbo].[EmployeeTerritories]
ADD CONSTRAINT [FK_EmployeeTerritories_Territories]
    FOREIGN KEY ([Territories_TerritoryID])
    REFERENCES [dbo].[Territories]
        ([TerritoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeTerritories_Territories'
CREATE INDEX [IX_FK_EmployeeTerritories_Territories]
ON [dbo].[EmployeeTerritories]
    ([Territories_TerritoryID]);
GO

-- Creating foreign key on [EmployeeID] in table 'Employees_SubEmployee'
ALTER TABLE [dbo].[Employees_SubEmployee]
ADD CONSTRAINT [FK_SubEmployee_inherits_Employee]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------