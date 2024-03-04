CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(MAX)
)
INSERT INTO [Directors] ([DirectorName], [Notes])
	VALUES
	('Vasil Lazarov', 'Directors rank: 1'),
	('Anelia Ahmedova', 'Directors rank: 2'),
	('Martin Kachev', 'Directors rank: 3'),
	('Ivailo Krustev', 'Directors rank: 4'),
	('Borislav Kalinski', 'Directors rank: 5')

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName]  VARCHAR(20) NOT NULL,
	[Notes] VARCHAR(MAX) DEFAULT('Empty')
)
INSERT INTO [Genres] ([GenreName])
	VALUES
	('genre1'),
	('genre2'),
	('genre3'),
	('genre4'),
	('genre5')

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName]  VARCHAR(20) NOT NULL,
	[Notes] VARCHAR(MAX) DEFAULT('Empty')
)
INSERT INTO [Categories] ([CategoryName])
	VALUES
	('category1'),
	('category2'),
	('category3'),
	('category4'),
	('category5')

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(100) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] SMALLINT,
	[Length] TIME,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] DECIMAL(3, 1),
	[Notes] VARCHAR(MAX) DEFAULT ('Empty')
)
INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating])
	VALUES
	('Star Wars', 3, 2006, '02:32:48', 2, 4, 7.6),
	('Fast and furious', 1, 2023, '02:12:37', 5, 3, 10),
	('The Meg 2', 4, 2022, '02:03:51', 1, 5, 8.3),
	('Avengers', 2, 2012, '02:24:13', 4, 1, 9.7),
	('Mission Impossible', 5, 2016, '01:58:09', 3, 2, 8.5)

SELECT * FROM [Movies]







