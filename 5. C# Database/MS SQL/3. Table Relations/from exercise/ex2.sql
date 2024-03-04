USE [MyFirstDB]
GO

CREATE TABLE [Manufacturers](
	[ManufacturerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	[EstablishedOn] DATE NOT NULL
)
--GO
INSERT INTO [Manufacturers]
	 VALUES
		('BMW', '07/03/1916'),
		('Tesla', '01/01/2003'),
		('Lada', '01/05/1966')
--GO

CREATE TABLE [Models](
	[ModelID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(20) NOT NULL,
	[ManufacturerID] INT NOT NULL,
	FOREIGN KEY ([ManufacturerID]) REFERENCES [Manufacturers]([ManufacturerID])
)
--GO
INSERT INTO [Models]
	 VALUES
	 ('X1', 1),
	 ('i6', 1),
	 ('Model S', 2),
	 ('Model X', 2)














