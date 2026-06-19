-- Script tạo database MyStore (chạy 1 lần trong SQL Server Management Studio)

CREATE DATABASE MyStore;
GO

USE MyStore;
GO

CREATE TABLE Categories (
    CategoryId   INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Products (
    ProductId     INT IDENTITY(1,1) PRIMARY KEY,
    ProductName   NVARCHAR(255) NOT NULL,
    Price         DECIMAL(18,2) NULL,
    UnitsInStock  INT NULL,
    CategoryId    INT NULL,
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId)
        REFERENCES Categories(CategoryId) ON DELETE SET NULL
);
GO

CREATE TABLE AccountMember (
    AccountId INT IDENTITY(1,1) PRIMARY KEY,
    UserName  NVARCHAR(50) NOT NULL UNIQUE,
    Password  NVARCHAR(50) NOT NULL,
    FullName  NVARCHAR(100) NULL,
    Email     NVARCHAR(100) NULL
);
GO

-- Dữ liệu mẫu
INSERT INTO Categories (CategoryName) VALUES (N'Electronics'), (N'Groceries'), (N'Clothing');
GO

INSERT INTO Products (ProductName, Price, UnitsInStock, CategoryId) VALUES
(N'Wireless Mouse', 15.99, 50, 1),
(N'Bluetooth Speaker', 29.99, 30, 1),
(N'Rice 5kg', 8.50, 100, 2),
(N'T-Shirt', 12.00, 75, 3);
GO

INSERT INTO AccountMember (UserName, Password, FullName, Email) VALUES
(N'admin', N'123456', N'Administrator', N'admin@productstore.com');
GO
