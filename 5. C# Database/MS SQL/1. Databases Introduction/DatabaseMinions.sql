--EXERCISE 1
CREATE DATABASE [Minions]

USE [Minions]

GO
GO

--EXERCISE 2
CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY, --CAN USE IDENTITY FOR DEFAULT IDs
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(70) NOT NULL
)

--EXERCISE 3
ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

--EXERCISE 4
GO 

INSERT INTO [Towns]([Id], [Name])
	VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

GO

--Make column Age Nullable
ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

GO

SELECT * FROM [Towns]
SELECT * FROM [Minions]

SELECT [Name], [Age]
	FROM [Minions]

GO

--EXERCISE 5 - DELETE DATA FROM TABLE
TRUNCATE TABLE [Minions]

--EXERCISE 6 - DELETE TABLE
--DROP TABLE [TABLE_NAME]





