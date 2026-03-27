USE master;
GO

-- 1. XỬ LÝ DATABASE CŨ (Đảm bảo không bị kẹt kết nối)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'Quanlybanhang')
BEGIN
    ALTER DATABASE Quanlybanhang SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Quanlybanhang;
END
GO

CREATE DATABASE Quanlybanhang;
GO

USE Quanlybanhang;
GO

-- 2. TẠO CẤU TRÚC BẢNG (TABLES)

-- Bảng Users (tích hợp Role trực tiếp để khớp với UserDAL.cs và UserDTO.cs)
CREATE TABLE Users (
    UserID      INT PRIMARY KEY IDENTITY(1,1),
    UserName    NVARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName    NVARCHAR(100) NOT NULL,
    Email       NVARCHAR(100) NULL,
    Phone       NVARCHAR(15)  NULL,
    Role        NVARCHAR(20)  NOT NULL DEFAULT N'Staff',   -- 'Admin' hoặc 'Staff'
    IsActive    BIT           NOT NULL DEFAULT 1,
    CreatedDate DATETIME      NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Categories (
    CategoryID   INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL UNIQUE,
    Description  NVARCHAR(500) NULL
);

CREATE TABLE Suppliers (
    SupplierID   INT PRIMARY KEY IDENTITY(1,1),
    SupplierName NVARCHAR(150) NOT NULL UNIQUE,
    Phone        NVARCHAR(15)  NULL,
    Address      NVARCHAR(255) NULL
);

-- Bảng Products (có IsActive, CreatedDate để khớp với ProductDTO.cs)
CREATE TABLE Products (
    ProductID   INT PRIMARY KEY IDENTITY(1,1),
    ProductCode NVARCHAR(50)   NOT NULL UNIQUE,
    ProductName NVARCHAR(150)  NOT NULL,
    CategoryID  INT            NOT NULL,
    SupplierID  INT            NOT NULL,
    CostPrice   DECIMAL(18,2)  NOT NULL CHECK (CostPrice >= 0),
    SellPrice   DECIMAL(18,2)  NOT NULL CHECK (SellPrice >= 0),
    Quantity    INT            NOT NULL DEFAULT 0 CHECK (Quantity >= 0),
    MinQuantity INT            NOT NULL DEFAULT 10,
    Unit        NVARCHAR(20)   NULL,
    IsActive    BIT            NOT NULL DEFAULT 1,           -- Xóa mềm
    CreatedDate DATETIME       NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Products_Category FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    CONSTRAINT FK_Products_Supplier FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);

-- Bảng Customers (có Email, Address, LoyaltyPoints để khớp với CustomerDTO.cs)
CREATE TABLE Customers (
    CustomerID   INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    Phone        NVARCHAR(15)  NOT NULL UNIQUE,
    Email        NVARCHAR(100) NULL,
    Address      NVARCHAR(255) NULL,
    TotalSpent   DECIMAL(18,2) NOT NULL DEFAULT 0,
    LoyaltyPoints INT          NOT NULL DEFAULT 0,
    CreatedDate  DATETIME      NOT NULL DEFAULT GETDATE()
);

-- Bảng Orders (có PaymentMethod, OrderStatus, Notes để khớp với OrderDTO.cs)
CREATE TABLE Orders (
    OrderID       INT PRIMARY KEY IDENTITY(1,1),
    OrderCode     NVARCHAR(50)   NOT NULL UNIQUE,
    CustomerID    INT            NULL,
    UserID        INT            NOT NULL,
    OrderDate     DATETIME       NOT NULL DEFAULT GETDATE(),
    TotalAmount   DECIMAL(18,2)  NOT NULL DEFAULT 0,
    Discount      DECIMAL(18,2)  NOT NULL DEFAULT 0,
    FinalAmount   DECIMAL(18,2)  NOT NULL DEFAULT 0,
    PaymentMethod NVARCHAR(50)   NULL DEFAULT N'Tiền mặt',  -- 'Tiền mặt', 'Thẻ', 'Chuyển khoản'
    OrderStatus   NVARCHAR(20)   NOT NULL DEFAULT N'Hoàn thành', -- 'Hoàn thành', 'Hủy'
    Notes         NVARCHAR(500)  NULL,
    CONSTRAINT FK_Orders_Customer FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    CONSTRAINT FK_Orders_User     FOREIGN KEY (UserID)     REFERENCES Users(UserID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID       INT            NOT NULL,
    ProductID     INT            NOT NULL,
    Quantity      INT            NOT NULL CHECK (Quantity > 0),
    UnitPrice     DECIMAL(18,2)  NOT NULL,
    LineTotal     AS (Quantity * UnitPrice) PERSISTED,
    CONSTRAINT FK_OrderDetails_Order   FOREIGN KEY (OrderID)   REFERENCES Orders(OrderID) ON DELETE CASCADE,
    CONSTRAINT FK_OrderDetails_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE InventoryLogs (
    LogID          INT PRIMARY KEY IDENTITY(1,1),
    ProductID      INT         NOT NULL,
    OrderID        INT         NULL,
    ChangeType     NVARCHAR(20) NULL,  -- 'BanHang', 'NhapKho', 'DieuChinh'
    QuantityChange INT         NOT NULL,
    LogDate        DATETIME    NOT NULL DEFAULT GETDATE()
);
GO

-- 3. TRIGGER: Tự động trừ tồn kho & tích điểm khách hàng khi tạo đơn hàng
CREATE TRIGGER TR_AutoUpdateStock_And_Points
ON OrderDetails
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Giảm tồn kho
    UPDATE P
    SET P.Quantity = P.Quantity - I.Quantity
    FROM Products P
    INNER JOIN inserted I ON P.ProductID = I.ProductID;

    -- Ghi log kho
    INSERT INTO InventoryLogs (ProductID, OrderID, ChangeType, QuantityChange)
    SELECT ProductID, OrderID, N'BanHang', -Quantity FROM inserted;

    -- Tích điểm & cộng tổng chi tiêu (1 điểm / 100,000 VND)
    UPDATE C
    SET C.LoyaltyPoints = C.LoyaltyPoints + CAST(O.FinalAmount / 100000 AS INT),
        C.TotalSpent    = C.TotalSpent + O.FinalAmount
    FROM Customers C
    INNER JOIN Orders O ON C.CustomerID = O.CustomerID
    INNER JOIN (SELECT DISTINCT OrderID FROM inserted) I ON O.OrderID = I.OrderID;
END;
GO

-- 4. DỮ LIỆU MẪU

INSERT INTO Users (UserName, PasswordHash, FullName, Email, Phone, Role)
VALUES
    (N'admin',  N'admin123',  N'Quan Tri Vien', N'admin@shop.com',  N'0901234567', N'Admin'),
    (N'staff1', N'staff123',  N'Nhan Vien 1',   N'staff1@shop.com', N'0912345678', N'Staff');

INSERT INTO Categories (CategoryName, Description)
VALUES
    (N'Do Uong', N'Cac loai nuoc giai khat'),
    (N'Thuc Pham Kho', N'Banh keo, mi goi, do kho');

INSERT INTO Suppliers (SupplierName, Phone, Address)
VALUES
    (N'Cong Ty Nuoc Giai Khat', N'0281234567', N'123 Nguyen Van Linh, Q7, HCM'),
    (N'Cong Ty Thuc Pham XYZ',  N'0289876543', N'456 Le Van Sy, Q3, HCM');

INSERT INTO Products (ProductCode, ProductName, CategoryID, SupplierID, CostPrice, SellPrice, Quantity, MinQuantity, Unit)
VALUES
    (N'COCA01', N'Coca Cola 330ml', 1, 1, 5000,  10000, 100, 10, N'Lon'),
    (N'PEPSI01', N'Pepsi 330ml',    1, 1, 4500,   9500, 80,  10, N'Lon'),
    (N'MiHao01', N'Mi Hao Hao Tom', 2, 2, 4000,   6500, 200, 20, N'Goi');

INSERT INTO Customers (CustomerName, Phone, Email, Address)
VALUES
    (N'Khach Le',    N'0900000000', NULL, NULL),
    (N'Nguyen Van A', N'0911111111', N'nva@email.com', N'123 ABC, HCM');
GO

-- 5. KIỂM TRA

SELECT 'Users'       AS [Table], COUNT(*) AS [Rows] FROM Users
UNION ALL
SELECT 'Products',                COUNT(*)           FROM Products
UNION ALL
SELECT 'Categories',              COUNT(*)           FROM Categories
UNION ALL
SELECT 'Suppliers',               COUNT(*)           FROM Suppliers
UNION ALL
SELECT 'Customers',               COUNT(*)           FROM Customers;
GO

-- Kiểm tra cấu trúc bảng Users
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Users'
ORDER BY ORDINAL_POSITION;
GO

SELECT * FROM Users;
GO
