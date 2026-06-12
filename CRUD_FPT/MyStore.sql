-- Setup database for Database First approach
USE master;
GO

-- Create database if not exists
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MyStore')
BEGIN
    CREATE DATABASE MyStore;
END
GO

USE MyStore;
GO

-- Drop tables if they exist to start fresh
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
    DROP TABLE dbo.Products;
GO

IF OBJECT_ID('dbo.Categories', 'U') IS NOT NULL
    DROP TABLE dbo.Categories;
GO

-- Create Categories Table
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) NOT NULL,
    CategoryName NVARCHAR(15) NOT NULL,
    CONSTRAINT PK__Categori__19093A2BFB66F4EB PRIMARY KEY (CategoryID)
);
GO

-- Create Products Table
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) NOT NULL,
    ProductName NVARCHAR(40) NOT NULL,
    UnitPrice MONEY NOT NULL,
    UnitsInStock SMALLINT NOT NULL,
    CategoryID INT NOT NULL,
    CONSTRAINT PK__Products__B40CC6EDFC1E3FB5 PRIMARY KEY (ProductID),
    CONSTRAINT FK__Products__Catego__3A81B327 FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
GO

-- Insert Sample Data for Testing
INSERT INTO Categories (CategoryName) VALUES 
(N'Beverages'),
(N'Condiments'),
(N'Confections'),
(N'Dairy Products'),
(N'Grains/Cereals');
GO

INSERT INTO Products (ProductName, UnitPrice, UnitsInStock, CategoryID) VALUES
(N'Chai', 18.00, 39, 1),
(N'Chang', 19.00, 17, 1),
(N'Aniseed Syrup', 10.00, 13, 2),
(N'Chef Anton''s Cajun Seasoning', 22.00, 53, 2),
(N'Chef Anton''s Gumbo Mix', 21.35, 0, 2);
GO
