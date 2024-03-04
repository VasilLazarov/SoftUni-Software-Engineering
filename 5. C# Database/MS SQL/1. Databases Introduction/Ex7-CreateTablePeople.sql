USE [Minions]

CREATE TABLE [People] (
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3, 2), -- For set default value use - DEFAULT (value)
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People] ([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
	('Vasil', 1.88, 83.7, 'm', '2000-09-24'),
	('Marto', 1.83, 75.2, 'm', '2000-07-14'),
	('Anelia', 1.68, 45.3, 'f', '2000-05-25'),
	('Ivailo', 1.77, 72.6, 'm', '2000-03-07'),
	('Georgi', 1.90, 85.4, 'm', '2000-11-11')

SELECT * FROM [People]

--EXERCISE 11 - for example - Change default value of Biography
ALTER TABLE [People]
ADD CONSTRAINT DF_DefaultBiography DEFAULT ('No biography provided...') FOR [Biography]




