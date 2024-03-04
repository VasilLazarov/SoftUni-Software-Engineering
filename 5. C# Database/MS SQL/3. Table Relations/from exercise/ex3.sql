USE [MyFirstDB]
GO

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL
)
--GO
INSERT INTO [Students]
	 VALUES
		('Mila'),
		('Toni'),
		('Ron')
--GO

CREATE TABLE [Exams](
	[ExamID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(20) NOT NULL
)
--GO
INSERT INTO [Exams]
	 VALUES
		('SpringMVC'),
		('Neo4j'),
		('Oracle 11g')
--GO

CREATE TABLE [StudentsExams](
	[StudentID] INT NOT NULL,
	[ExamID] INT NOT NULL,
	FOREIGN KEY ([StudentID]) REFERENCES [Students]([StudentID]),
	FOREIGN KEY ([ExamID]) REFERENCES [Exams]([ExamID]),
	PRIMARY KEY ([StudentID], [ExamID])
)
--GO
INSERT INTO [StudentsExams]
	 VALUES
		(1, 101),
		(1, 102),
		(2, 101),
		(3, 103),
		(2, 102),
		(2, 103)















