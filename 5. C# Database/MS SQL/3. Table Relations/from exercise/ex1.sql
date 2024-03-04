USE [MyFirstDB]
GO

CREATE TABLE [Passports](
	[PassportID] INT PRIMARY KEY,
	[PassportNumber] CHAR(8) NOT NULL
)
GO
INSERT INTO [Passports]
	 VALUES
		(101, 'N34FG21B'),
		(102, 'K65LO4R7'),
		(103, 'ZE657QP2')
GO

CREATE TABLE [Persons](
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[Salary] DECIMAL(8, 2) NOT NULL,
	[PassportID] INT UNIQUE NOT NULL,
	FOREIGN KEY ([PassportID]) REFERENCES [Passports]([PassportID])
)
GO
INSERT INTO [Persons]
	 VALUES
		('Roberto', 43300, 102),
		('Tom', 56100, 103),
		('Yana', 60200, 101)












