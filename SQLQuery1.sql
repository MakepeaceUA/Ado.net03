CREATE TABLE ProductTypes (
    Id INT PRIMARY KEY,
    TypeName VARCHAR(255) NOT NULL
);


CREATE TABLE Suppliers (
    Id INT PRIMARY KEY,
    SupplierName VARCHAR(255) NOT NULL 
);


CREATE TABLE Products (
    Id INT  PRIMARY KEY,
    ProductName VARCHAR(255) NOT NULL,
    ProductTypeId INT NOT NULL,
    SupplierId INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity >= 0),
    CostPrice DECIMAL(10,2) NOT NULL CHECK (CostPrice >= 0),
    SupplyDate DATE NOT NULL,
    FOREIGN KEY (ProductTypeId) REFERENCES ProductTypes(Id),
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id)
);

INSERT INTO ProductTypes (Id,TypeName) VALUES
(1, 'ќвощи'),
(2, '‘рукты')


INSERT INTO Suppliers (Id,SupplierName) VALUES
(1,'Suppliers1'),
(2,'Suppliers2')


INSERT INTO Products (Id,ProductName, ProductTypeId, SupplierId, Quantity, CostPrice, SupplyDate) VALUES
(1,'яблоко', 2, 2, 100, 50.00, '2025-03-25'),
(2,'Ѕананы', 2, 2, 120, 60.00, '2025-03-26')


