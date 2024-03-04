CREATE DATABASE [University-ExRelations]
--GO
USE [University-ExRelations]
--GO

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL
)
--GO

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[StudentNumber] VARCHAR(10) UNIQUE NOT NULL,
	[StudentName] VARCHAR(20) NOT NULL,
	[MajorID] INT NOT NULL,
	FOREIGN KEY ([MajorID]) REFERENCES [Majors]([MajorID])
)
--GO

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY IDENTITY,
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] DECIMAL(8, 2) NOT NULL,
	[StudentID] INT NOT NULL,
	FOREIGN KEY ([StudentID]) REFERENCES [Students]([StudentID])
)
--GO

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY IDENTITY,
	[SubjectName] VARCHAR(20) NOT NULL
)
--GO

CREATE TABLE [Agenda](
	[StudentID] INT NOT NULL,
	[SubjectID] INT NOT NULL,
	FOREIGN KEY ([StudentID]) REFERENCES [Students]([StudentID]),
	FOREIGN KEY ([SubjectID]) REFERENCES [Subjects]([SubjectID]),
	PRIMARY KEY ([StudentID], [SubjectID])
)












