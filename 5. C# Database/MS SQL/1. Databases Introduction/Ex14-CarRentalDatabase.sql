CREATE DATABASE [CarRental]
GO

USE [CarRental]
GO

--TABLE CATEGORIES
CREATE TABLE [Categories](
	   [Id] INT PRIMARY KEY IDENTITY
	 , [CategoryName] VARCHAR(20) NOT NULL
	 , [DailyRate] INT NOT NULL
	 , [WeeklyRate] INT NOT NULL
	 , [MonthlyRate] INT NOT NULL
	 , [WeekendRate] INT NOT NULL
)
--GO
INSERT INTO [Categories]
	 VALUES
		('cat1', 15, 105, 440, 30),
		('cat3', 12, 84, 366, 24),
		('cat3', 18, 126, 550, 36)
--GO

--TABLE CARS
CREATE TABLE [Cars](
	  [Id] INT PRIMARY KEY IDENTITY
	, [PlateNumber] VARCHAR(10) NOT NULL
	, [Manufacturer] VARCHAR(20) NOT NULL
	, [Model] VARCHAR(20) NOT NULL
	, [CarYear] SMALLINT
	, [CategoryId] INT CONSTRAINT FK_CarCategoryId FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL
	, [Doors] TINYINT
	, [Picture] VARBINARY(MAX)
	, [Condition] VARCHAR(50)
	, [Available] VARCHAR(5) NOT NULL
)
--GO
INSERT INTO [Cars]
	VALUES
		('CB1847XH', 'BMW', 'i8', 2018, 3, 2, NULL, 'Very Good', 'true'),
		('CB7777VL', 'Audi', 'RS8', 2019, 1, 4, NULL, 'Perfect', 'true'),
		('CB3261XH', 'Volkswagen', 'Golf4', 2012, 2, 4, NULL, 'Good', 'true')
--GO

--TABLE EMPLOYEES
CREATE TABLE [Employees](
	  [Id] INT PRIMARY KEY IDENTITY
	, [FirstName] VARCHAR(20) NOT NULL
	, [LastName] VARCHAR(20) NOT NULL
	, [Title] VARCHAR(10) NOT NULL
	, [Notes] VARCHAR(100)
)
--GO
INSERT INTO [Employees]
	VALUES
		('Vasil', 'Lazarov', 'Seller', NULL),
		('Aneliq', 'Ahmedova', 'Seller', NULL),
		('Martin', 'Kachev', 'Seller', NULL)
--GO

--TABLE CUSTOMERS
CREATE TABLE [Customers](
	  [Id] INT PRIMARY KEY IDENTITY
	, [DriverLicenceNumber] VARCHAR(10) NOT NULL
	, [FullName] VARCHAR(50) NOT NULL
	, [Address] VARCHAR(30) NOT NULL
	, [City] VARCHAR(20) NOT NULL
	, [ZIPCode] SMALLINT NOT NULL
	, [Notes] VARCHAR(100)
)
--GO
INSERT INTO [Customers]
	VALUES
		('1403230001', 'Borislav Kalinski', 'st.Vasil Levski 20', 'Sofia', 1000, NULL),
		('1403230002', 'Isa-Vasil Ivanov', 'st.Hristo Botev 10', 'Plovdiv', 4000, NULL),
		('1403230003', 'Jonh Atanasov', 'st.Geo Milev 7', 'Sofia', 1000, NULL)
--GO

--TABLE RENTALORDERS
CREATE TABLE [RentalOrders](
	  [Id] INT PRIMARY KEY IDENTITY
	, [EmployeeId] INT CONSTRAINT FK_SellerId FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL
	, [CustomerId] INT CONSTRAINT FK_CustomerId FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL
	, [CarId] INT CONSTRAINT FK_CarId FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL
	, [TankLevel] INT NOT NULL
	, [KilometrageStart] INT NOT NULL
	, [KilometrageEnd] INT NOT NULL
	, [TotalKilometrage] INT NOT NULL
	, [StartDate] DATE NOT NULL
	, [EndDate] DATE NOT NULL
	, [TotalDays] INT NOT NULL
	, [RateApplied] INT NOT NULL
	, [TaxRate] INT NOT NULL
	, [OrderStatus] VARCHAR(10) NOT NULL
	, [Notes] VARCHAR(100)
)
--GO
INSERT INTO [RentalOrders]
	VALUES
		(1, 1, 1, 50, 3000, 3700, 700, '2023-09-02', '2023-09-14', 12, 22, 37, 'no info', NULL),
		(2, 2, 2, 50, 3000, 3700, 700, '2023-09-02', '2023-09-14', 12, 22, 37, 'no info', NULL),
		(3, 3, 3, 50, 3000, 3700, 700, '2023-09-02', '2023-09-14', 12, 22, 37, 'no info', NULL)

