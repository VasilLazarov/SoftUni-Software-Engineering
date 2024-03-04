CREATE DATABASE [Hotel]
GO

USE [Hotel]
GO

--TABLE EMPLOYEES
CREATE TABLE [Employees](
	  [Id] INT PRIMARY KEY IDENTITY
	, [FirstName] VARCHAR(20) NOT NULL
	, [LastName] VARCHAR(20) NOT NULL
	, [Title] VARCHAR(20) NOT NULL
	, [Notes] VARCHAR(100)
)
--GO
INSERT INTO [Employees]
	VALUES
		('Emp1', 'DDZ', 'Receptionist', NULL),
		('Emp2', 'DDZ', 'Receptionist', NULL),
		('Emp3', 'DDZ', 'Receptionist', NULL)
--GO

--TABLE CUSTOMERS
CREATE TABLE [Customers](
	  [AccountNumber] INT PRIMARY KEY IDENTITY
	, [FirstName] VARCHAR(20) NOT NULL
	, [LastName] VARCHAR(20) NOT NULL
	, [PhoneNumber] VARCHAR(10) NOT NULL
	, [EmergencyName] VARCHAR(20) NOT  NULL
	, [EmergencyNumber] VARCHAR(5) NOT NULL
	, [Notes] VARCHAR(100)
)
--GO
INSERT INTO [Customers]
	VALUES
		('Jack', 'Davidson', '0888222555', 'SOS', '112', NULL),
		('Dany', 'Jackson', '0888555222', 'SOS', '112', NULL),
		('Ddz', 'Random', '0888333777', 'SOS', '112', NULL)
--GO

--TABLE ROOMSTATUS
CREATE TABLE [RoomStatus](
	  [RoomStatus] VARCHAR(10) PRIMARY KEY
	, [Notes] VARCHAR(100)
)
--GO
INSERT INTO [RoomStatus]
	VALUES
		('RoomSt1', null),
		('RoomSt2', null),
		('RoomSt3', null)
--GO

--TABLE ROOMTYPES
CREATE TABLE [RoomTypes](
	  [RoomType] VARCHAR(10) PRIMARY KEY
	, [Notes] VARCHAR(100)
)
--GO
INSERT INTO [RoomTypes]
	VALUES
		('Small', null),
		('Normal', null),
		('Big', null)
--GO

--TABLE BEDTYPES
CREATE TABLE [BedTypes](
	[BedType] VARCHAR(10) PRIMARY KEY
	, [Notes] VARCHAR(100)
)
--GO
INSERT INTO [BedTypes]
	VALUES
		('Single', null),
		('Double', null),
		('Extra', null)
--GO

--TABLE ROOMS
CREATE TABLE [Rooms](
	  [RoomNumber] INT PRIMARY KEY
	, [RoomType] VARCHAR(10) CONSTRAINT FK_Room_RoomType FOREIGN KEY REFERENCES [RoomTypes]([RoomType])
	, [BedType] VARCHAR(10) CONSTRAINT FK_Room_BedType FOREIGN KEY REFERENCES [BedTypes]([BedType])
	, [Rate] DECIMAL(3, 1)
	, [RoomStatus] VARCHAR(10) CONSTRAINT FK_Room_RoomStatus FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus])
	, [Notes] VARCHAR(100)
)
--GO
INSERT INTO [Rooms]
	VALUES
		(301, )








