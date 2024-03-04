CREATE DATABASE Boardgames
GO
USE Boardgames
GO
--EX1 CREATE TABLES
--1.Adresses
CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL
)
--GO
--2.Publishers
CREATE TABLE Publishers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) UNIQUE NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES [Addresses](Id) NOT NULL,
	Website NVARCHAR(40) NOT NULL,
	Phone NVARCHAR(20) NOT NULL
)
--GO
--3.PlayerRanges
CREATE TABLE PlayersRanges(
	Id INT PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL
)
--GO
--4.Categories
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)
--GO
--5.Boardgames
CREATE TABLE Boardgames(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(3, 2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	PublisherId INT FOREIGN KEY REFERENCES [Publishers](Id) NOT NULL,
	PlayersRangeId INT FOREIGN KEY REFERENCES [PlayersRanges](Id) NOT NULL
)
--GO
--6.Creators
CREATE TABLE Creators(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL
)
--GO
--7.CreatorsBoardgames
CREATE TABLE CreatorsBoardgames(
	CreatorId INT FOREIGN KEY REFERENCES [Creators](Id) NOT NULL,
	BoardgameId INT FOREIGN KEY REFERENCES [Boardgames](Id) NOT NULL,
	PRIMARY KEY (CreatorId, BoardgameId)
)
--GO



--CRUD OPERATIONS
--EX2
INSERT INTO Boardgames
	VALUES
		('Deep Blue', 2019, 5.67, 1, 15, 7),
		('Paris', 2016, 9.78, 7, 1, 5),
		('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
		('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
		('One Small Step', 2019, 5.75, 5, 9, 2)
INSERT INTO Publishers
	VALUES
		('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
		('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
		('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

--EX3
UPDATE PlayersRanges
   SET PlayersMax +=1
 WHERE PlayersMax = 2 
   AND PlayersMin = 2

UPDATE Boardgames
   SET [Name] += 'V2'
 WHERE YearPublished >= 2020

--EX4
DELETE FROM CreatorsBoardgames
 WHERE BoardgameId IN (
		SELECT Id
		  FROM Boardgames
		 WHERE PublisherId IN(
				SELECT Id
				  FROM Publishers
				 WHERE AddressId IN(
						SELECT Id
						  FROM Addresses
						 WHERE Town LIKE 'L%'
						 )
				 )
		 )

DELETE FROM Boardgames
 WHERE PublisherId IN(
		SELECT Id
		  FROM Publishers
		 WHERE AddressId IN(
				SELECT Id
				  FROM Addresses
				 WHERE Town LIKE 'L%'
						 )
				 )

DELETE FROM Publishers
 WHERE AddressId IN(
		SELECT Id
		  FROM Addresses
		 WHERE Town LIKE 'L%')

DELETE FROM Addresses
 WHERE Town LIKE 'L%'



--QUERIES
--EX5
SELECT [Name]
     , Rating
  FROM Boardgames
ORDER BY YearPublished, [Name] DESC
--FOR TEST
SELECT [Name]
     , Rating
FROM Boardgames
WHERE [Name] = 'Santa Monica'

--EX6
SELECT b.Id
     , b.[Name]
	 , b.YearPublished
	 , c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON b.CategoryId = c.Id
WHERE c.[Name] IN ('Strategy Games', 'Wargames')
ORDER BY YearPublished DESC

--EX7
SELECT c.Id
     , CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName
	 , c.Email
  FROM Creators AS c
  LEFT JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
 WHERE BoardgameId IS NULL
ORDER BY CreatorName

--EX8
SELECT TOP(5)
       b.[Name]
     , b.Rating
	 , c.[Name]
  FROM Boardgames AS b
  JOIN Categories AS c ON b.CategoryId = c.Id
  JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
 WHERE b.Rating > 7 AND CHARINDEX('a', b.[Name]) > 0
    OR b.Rating > 7.5 AND pr.PlayersMax = 5 AND pr.PlayersMin = 2
ORDER BY b.[Name], b.Rating DESC

--EX9
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName
     , c.Email
	 , MAX(b.Rating)
  FROM CreatorsBoardgames AS cb
  JOIN Creators AS c ON cb.CreatorId = c.Id
  JOIN Boardgames AS b ON cb.BoardgameId = b.Id
GROUP BY c.FirstName, c.LastName, c.Email
HAVING RIGHT(c.Email, 4) = '.com'
ORDER BY FullName

--EX10
--!!!!!!!!!!!!
--ORDER BY SAME AS SELECT TO WITH ALIAS BECAUSE DONT WORK CORRECTLY
--!!!!!!!!!!!!
SELECT c.LastName
     , CEILING(AVG(b.Rating)) AS AverageRating
	 , p.[Name] AS PublisherName
  FROM CreatorsBoardgames AS cb
  JOIN Creators AS c ON cb.CreatorId = c.Id
  JOIN Boardgames AS b ON cb.BoardgameId = b.Id
  JOIN Publishers AS p ON b.PublisherId = p.Id
 --WHERE p.[Name] = 'Stonemaier Games'
GROUP BY c.LastName, p.[Name]
HAVING p.[Name] = 'Stonemaier Games'
ORDER BY AVG(b.Rating) DESC




--FUNCTIONS AND STORED PROCEDURES
--EX11
--SCALAR
GO
CREATE OR ALTER FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @num INT
	SET @num = (Select COUNT(*)
				  FROM CreatorsBoardgames AS cb
				  JOIN Creators AS c ON cb.CreatorId = c.Id
				 WHERE c.[FirstName] = @name
			   )
	RETURN @num
END
GO
SELECT dbo.udf_CreatorWithBoardgames('Bruno')

--DONT WORK - WE NEED SCALAR FUNCTION
GO
CREATE OR ALTER FUNCTION udf_CreatorWithBoardgames_NotScalar(@name NVARCHAR(30))
RETURNS TABLE
AS
RETURN(
	 SELECT COUNT(*) AS [CTN]
	  FROM Creators AS c
	  LEFT JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
	 WHERE c.[FirstName] = @name
)
GO
SELECT * FROM dbo.udf_CreatorWithBoardgames('Bruno')

--EX12
GO
CREATE PROC usp_SearchByCategory(@category VARCHAR(50))
AS
	SELECT b.[Name]
	     , b.YearPublished
		 , b.Rating
		 , c.[Name] AS CategoryName
		 , p.[Name] AS PublisherName
		 , CONCAT(pr.PlayersMin, ' people') AS MinPlayers
		 , CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
	  FROM Boardgames AS b
	  JOIN Publishers AS p ON b.PublisherId = p.Id
	  JOIN Categories AS c ON b.CategoryId = c.Id
	  JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
	 WHERE c.[Name] = @category
	 ORDER BY p.[Name], b.YearPublished DESC

EXEC usp_SearchByCategory 'Wargames'

