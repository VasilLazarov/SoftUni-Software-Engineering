CREATE DATABASE Accounting
GO
USE Accounting
GO


--SECTION 1 - CREATE TABLES - 30pts

--EX1
CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)
GO
CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(20) NOT NULL,
	StreetNumber INT,
	PostCode INT NOT NULL,
	City VARCHAR(25) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)
GO
CREATE TABLE Vendors(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)
GO
CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)
GO
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)
GO
CREATE TABLE Products(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(35) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(Id) NOT NULL
)
GO
CREATE TABLE Invoices(
	Id INT PRIMARY KEY IDENTITY,
	Number INT UNIQUE NOT NULL,
	IssueDate DATETIME2 NOT NULL,
	DueDate DATETIME2 NOT NULL,
	Amount DECIMAL(18, 2) NOT NULL,
	Currency VARCHAR(5) NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
)
GO
CREATE TABLE ProductsClients(
	ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
	PRIMARY KEY (ProductId, ClientId)
)
GO



--SECTION 2 - CRUD OPERATINS - 10pts
--BEFORE START INPORT DATA FROM RESOURCE

--EX2 - INSERT
INSERT INTO Products
	VALUES
		('SCANIA Oil Filter XD01', 78.69, 1, 1),
		('MAN Air Filter XD01', 97.38, 1, 5),
		('DAF Light Bulb 05FG87', 55.00, 2, 13),
		('ADR Shoes 47-47.5', 49.85, 3, 5),
		('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO Invoices
	VALUES
		(1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
		(1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
		(1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19)

--EX3 - UPDATE
UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE YEAR(IssueDate) = 2022 AND MONTH(IssueDate) = 11

UPDATE Clients
SET AddressId = 3
WHERE CHARINDEX('CO', [Name]) > 0

--EX4 - DELETE
 DELETE FROM ProductsClients
 WHERE ClientId IN(
				   SELECT Id
				     FROM Clients
					WHERE SUBSTRING(NumberVAT, 1, 2) = 'IT'
				  )
 DELETE FROM Invoices
 WHERE ClientId IN(
				   SELECT Id
				     FROM Clients
					WHERE SUBSTRING(NumberVAT, 1, 2) = 'IT'
				  )
DELETE FROM Clients
WHERE SUBSTRING(NumberVAT, 1, 2) = 'IT'




--SECTION 3 - Queries - 40pts
--BEFORE START DELETE DATABASE AND CREATE
--AGAIN AND INSERT DATA FROM RESOURCES

--EX5
SELECT Number
     , Currency
  FROM Invoices
ORDER BY Amount DESC, DueDate


--EX6
  SELECT p.Id
       , p.[Name]
	   , p.Price
	   , c.[Name]
    FROM Products AS p
	JOIN Categories AS c ON p.CategoryId = c.Id
   WHERE c.[Name] IN ('ADR', 'Others')
ORDER BY p.Price DESC


--EX7
     SELECT c.Id
	      , c.[Name] AS Client
		  , CONCAT(a.StreetName, ' ', a.StreetNumber, ', ', a.City, ', ', a.PostCode, ', ', cr.[Name])
       FROM Clients AS c
  LEFT JOIN ProductsClients AS pc ON c.Id = pc.ClientId
       JOIN Addresses AS a ON c.AddressId = a.Id
	   JOIN Countries AS cr ON a.CountryId = cr.Id
	  WHERE pc.ProductId IS NULL
   ORDER BY c.[Name]


--EX8
SELECT TOP(7)
       i.Number
     , i.Amount
	 , c.[Name]
FROM Invoices AS i
JOIN Clients AS c ON i.ClientId = c.Id
WHERE i.IssueDate < '2023-01-01' AND i.Currency = 'EUR'
   OR i.Amount > 500 AND SUBSTRING(c.NumberVAT, 1, 2) = 'DE'
ORDER BY i.Number, i.Amount DESC


--EX9
SELECT c.[Name] AS Client
     , MAX(p.Price) AS Price
	 , c.NumberVAT
  FROM ProductsClients AS pc
  JOIN Products AS p ON pc.ProductId = p.Id
  JOIN Clients AS c ON pc.ClientId = c.Id
GROUP BY c.[Name], c.NumberVAT
HAVING RIGHT(c.[Name], 2) <> 'KG'
ORDER BY MAX(p.Price) DESC
 


--EX10
SELECT c.[Name] AS Client
     , FLOOR(AVG(p.Price)) AS [Average Price]
  FROM Clients AS c
  JOIN ProductsClients AS pc ON pc.ClientId = c.Id
  JOIN Products AS p ON pc.ProductId = p.Id
  JOIN Vendors AS v ON p.VendorId = v.Id
 --WHERE v.NumberVAT LIKE '%FR%'
 WHERE CHARINDEX('FR', v.NumberVAT) > 0
GROUP BY c.[Name]
ORDER BY AVG(p.Price), c.[Name] DESC






--SECTION 4 - FUNCTIONS AND STORED PROCEURES - 20pts

--EX11
GO
CREATE FUNCTION udf_ProductWithClients(@name NVARCHAR(35))
RETURNS INT
AS
BEGIN
	DECLARE @result INT
	SET @result = (
				  SELECT COUNT(*)
				    FROM ProductsClients AS pc
					JOIN Products AS p ON pc.ProductId = p.Id
				   WHERE p.[Name] = @name
				  )
	RETURN @result
END
GO
SELECT dbo.udf_ProductWithClients('DAF FILTER HU12103X')


--EX12
GO
CREATE OR ALTER PROC usp_SearchByCountry(@country VARCHAR(10))
AS
	SELECT v.[Name] AS Vendor
	     , v.[NumberVAT] AS VAT
		 , CONCAT(a.StreetName, ' ', a.StreetNumber) AS [Street Info]
		 , CONCAT(a.City, ' ', a.PostCode) AS [City Info]
	  FROM Vendors AS v
	  JOIN Addresses AS a ON v.AddressId = a.Id
	  JOIN Countries AS c ON a.CountryId = c.Id
	 WHERE c.[Name] = @country
	 ORDER BY v.[Name], a.City
GO
EXEC usp_SearchByCountry 'France'



