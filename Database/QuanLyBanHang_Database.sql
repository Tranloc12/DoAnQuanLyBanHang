USE master;
GO

SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
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

CREATE TABLE Users (
    UserID      INT PRIMARY KEY IDENTITY(1,1),
    UserName    NVARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName    NVARCHAR(100) NOT NULL,
    Email       NVARCHAR(100) NULL,
    Phone       NVARCHAR(15)  NULL,
    Role        NVARCHAR(20)  NOT NULL DEFAULT N'Staff',   
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
    IsActive    BIT            NOT NULL DEFAULT 1,         
    CreatedDate DATETIME       NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Products_Category FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    CONSTRAINT FK_Products_Supplier FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);

CREATE TABLE Customers (
    CustomerID   INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    Phone        NVARCHAR(15)  NOT NULL UNIQUE,
    Email        NVARCHAR(100) NULL,
    Address      NVARCHAR(255) NULL,
    TotalSpent   DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TotalSpent >= 0),
    LoyaltyPoints INT          NOT NULL DEFAULT 0 CHECK (LoyaltyPoints >= 0),
    CustomerRank  NVARCHAR(20)  NOT NULL DEFAULT N'Đồng', 
    CreatedDate  DATETIME      NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Orders (
    OrderID       INT PRIMARY KEY IDENTITY(1,1),
    OrderCode     NVARCHAR(50)   NOT NULL UNIQUE,
    CustomerID    INT            NULL,
    UserID        INT            NOT NULL,
    OrderDate     DATETIME       NOT NULL DEFAULT GETDATE(),
    TotalAmount   DECIMAL(18,2)  NOT NULL DEFAULT 0 CHECK (TotalAmount >= 0),
    Discount      DECIMAL(18,2)  NOT NULL DEFAULT 0 CHECK (Discount >= 0),
    FinalAmount   DECIMAL(18,2)  NOT NULL DEFAULT 0 CHECK (FinalAmount >= 0),
    PaymentMethod NVARCHAR(50)   NULL DEFAULT N'Tiền mặt',  
    OrderStatus   NVARCHAR(20)   NOT NULL DEFAULT N'Hoàn thành', 
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
    ChangeType     NVARCHAR(20) NULL,  
    QuantityChange INT         NOT NULL,
    LogDate        DATETIME    NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_InventoryLogs_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT FK_InventoryLogs_Order   FOREIGN KEY (OrderID)   REFERENCES Orders(OrderID) ON DELETE SET NULL
);
GO

-- 3. TRIGGERS: Tự động trừ tồn kho & tích điểm khách hàng

-- Trigger 1: Xử lý tồn kho (chạy khi thêm chi tiết đơn hàng)
CREATE TRIGGER TR_AutoUpdateStock
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
END;
GO

-- Trigger 2: Xử lý điểm thưởng & thứ hạng (chạy 1 lần duy nhất khi tạo hóa đơn)
CREATE TRIGGER TR_AutoUpdateCustomerPoints
ON Orders
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Tích điểm & cộng tổng chi tiêu (1 điểm / 100,000 VND)
    UPDATE C
    SET C.LoyaltyPoints = C.LoyaltyPoints + CAST(I.FinalAmount / 100000 AS INT),
        C.TotalSpent    = C.TotalSpent + I.FinalAmount
    FROM Customers C
    INNER JOIN inserted I ON C.CustomerID = I.CustomerID
    WHERE I.CustomerID IS NOT NULL;

    -- Tự động thăng hạng (Ranking) cho khách hàng dựa trên TotalSpent
    UPDATE C
    SET C.CustomerRank = 
        CASE 
            WHEN C.TotalSpent >= 500000 THEN N'Kim Cương'
            WHEN C.TotalSpent >= 200000  THEN N'Vàng'
            WHEN C.TotalSpent >= 100000  THEN N'Bạc'
            ELSE N'Đồng'
        END
    FROM Customers C
    INNER JOIN inserted I ON C.CustomerID = I.CustomerID
    WHERE I.CustomerID IS NOT NULL;
END;
GO

-- 4. DỮ LIỆU MẪU

-- 4. DỮ LIỆU MẪU
INSERT INTO Users (UserName, PasswordHash, FullName, Email, Phone, Role)
VALUES
    (N'admin',  N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918',  N'Quản Trị Viên', N'admin@shop.com',  N'0901234567', N'Admin'),
    (N'staff1', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',  N'Nhân Viên 1',   N'staff1@shop.com', N'0912345678', N'Staff');

INSERT INTO Categories (CategoryName, Description)
VALUES
    (N'Đồ Uống', N'Nước giải khát, nước ngọt, bia'),
    (N'Thực Phẩm Khô', N'Bánh kẹo, mì gói, đồ hộp'),
    (N'Gia Vị', N'Mắm, muối, bột ngọt, dầu ăn'),
    (N'Hóa Mỹ Phẩm', N'Dầu gội, sữa tắm, bột giặt');

INSERT INTO Suppliers (SupplierName, Phone, Address)
VALUES
    (N'Công Ty Nước Giải Khát Coca-Cola', N'0281234567', N'123 Nguyễn Văn Linh, Q7, HCM'),
    (N'Công Ty Cổ Phần Acecook VN',  N'0289876543', N'456 Lê Văn Sỹ, Q3, HCM'),
    (N'Tập Đoàn Unilever', N'0283333444', N'789 Điện Biên Phủ, Bình Thạnh, HCM'),
    (N'Công Ty TNHH Masan', N'0285555666', N'KCN Tân Bình, Tân Phú, HCM');

INSERT INTO Products (ProductCode, ProductName, CategoryID, SupplierID, CostPrice, SellPrice, Quantity, MinQuantity, Unit)
VALUES
    -- Đồ uống (Mã dễ gõ)
    (N'COCA01', N'Coca Cola 330ml', 1, 1, 8000, 10000, 200, 20, N'Lon'),
    (N'PEPSI01', N'Pepsi 330ml', 1, 1, 8000, 10000, 150, 20, N'Lon'),
    (N'NUOC01', N'Nước Suối Aquafina 500ml', 1, 1, 4000, 5000, 300, 50, N'Chai'),
    (N'BIA01', N'Bia Tiger Bạc 330ml', 1, 1, 16000, 19000, 120, 24, N'Lon'),
    
    -- Thực phẩm khô (Mã dễ gõ)
    (N'MI01', N'Mì Hảo Hảo Tôm Chua Cay', 2, 2, 3500, 4500, 500, 50, N'Gói'),
    (N'PHO01', N'Phở Trộn Đệ Nhất', 2, 2, 6000, 8000, 100, 20, N'Gói'),
    (N'BANH01', N'Bánh Snack Oishi Vị Cua', 2, 2, 4000, 5000, 80, 15, N'Gói'),
    
    -- Gia vị (Mã dễ gõ)
    (N'MAM01', N'Nước Mắm Nam Ngư 500ml', 3, 4, 30000, 36000, 60, 10, N'Chai'),
    (N'TUONG01', N'Nước Tương Chinsu 250ml', 3, 4, 15000, 18000, 75, 10, N'Chai'),
    (N'DAU01', N'Dầu Ăn Neptune 1 Lít', 3, 4, 45000, 55000, 40, 10, N'Chai'),
    
    -- Hóa mỹ phẩm (Mã dễ gõ)
    (N'GOI01', N'Dầu Gội Clear Men 630g', 4, 3, 150000, 175000, 30, 5, N'Chai'),
    (N'TAM01', N'Sữa Tắm Lifebuoy 850g', 4, 3, 120000, 140000, 40, 5, N'Chai'),
    (N'KEM01', N'Kem Đánh Răng PS Trà Xanh', 4, 3, 30000, 38000, 50, 10, N'Hộp');

INSERT INTO Customers (CustomerName, Phone, Email, Address, TotalSpent, LoyaltyPoints, CustomerRank)
VALUES
    (N'Khách Lẻ', N'0000000000', NULL, NULL, 0, 0, N'Đồng'),
    (N'Nguyễn Văn An', N'0901112223', N'an.nguyen@email.com', N'Quận 1, HCM', 50000, 0, N'Đồng'),
    (N'Trần Thị Bích', N'0902223334', N'bich.tran@email.com', N'Quận 3, HCM', 150000, 1, N'Bạc'),
    (N'Lê Hoàng Nam', N'0903334445', N'nam.le@email.com', N'Quận 7, HCM', 350000, 3, N'Vàng'),
    (N'Phạm Mai Phương', N'0904445556', N'phuong.pham@email.com', N'Tân Bình, HCM', 1200000, 12, N'Kim Cương');
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

