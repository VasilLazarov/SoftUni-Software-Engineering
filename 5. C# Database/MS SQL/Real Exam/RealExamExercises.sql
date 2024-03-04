CREATE DATABASE TouristAgency 
GO
USE TouristAgency 
GO


--SECTION 1 - CREATE TABLES - 30pts

--EX1
CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DestinationId INT FOREIGN KEY REFERENCES Destinations(Id) NOT NULL
)

CREATE TABLE Rooms (
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(40) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL,
	BedCount INT NOT NULL,
	CHECK (BedCount > 0 AND BedCount <=10)
)

CREATE TABLE Tourists(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Email VARCHAR(80),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Bookings(
	Id INT PRIMARY KEY IDENTITY,
	ArrivalDate DATETIME2 NOT NULL,
	DepartureDate DATETIME2 NOT NULL,
	AdultsCount INT NOT NULL,
	CHECK (AdultsCount >= 1 AND AdultsCount <=10),
	ChildrenCount INT NOT NULL,
	CHECK (ChildrenCount >= 0 AND ChildrenCount <=9),
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL
)

CREATE TABLE HotelsRooms(
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL
	PRIMARY KEY (HotelId, RoomId)
)





--SECTION 2 - CRUD OPERATINS - 10pts
--BEFORE START INPORT DATA FROM RESOURCE

--EX2 - INSERT
INSERT INTO Tourists
	VALUES
		('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
		('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
		('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
		('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
		('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)

INSERT INTO Bookings
	VALUES
		('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
		('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
		('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
		('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
		('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)


--EX3 - UPDATE
UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE YEAR(ArrivalDate) = 2023
  AND MONTH(ArrivalDate) = 12

UPDATE Tourists
SET Email = NULL
WHERE CHARINDEX('MA', [Name]) > 0

--EX4 - DELETE
DELETE FROM Bookings
WHERE TouristId IN(
		           SELECT Id
				     FROM Tourists
					WHERE RIGHT([Name], 5) = 'Smith'
				  )

DELETE FROM Tourists
WHERE RIGHT([Name], 5) = 'Smith'



--SECTION 3 - Queries - 40pts
--BEFORE START DELETE DATABASE AND CREATE
--AGAIN AND INSERT DATA FROM RESOURCES

--EX5
SELECT FORMAT(b.ArrivalDate, 'yyyy-MM-dd', 'bg-BG')
     , b.AdultsCount
	 , b.ChildrenCount
  FROM Bookings AS b
  JOIN Rooms AS r ON b.RoomId = r.Id
ORDER BY r.Price DESC, b.ArrivalDate


--EX6
 SELECT b.HotelId AS [Id]
      --, COUNT(*)
	  , h.[Name]
   FROM Bookings AS b
   JOIN Rooms AS r ON b.RoomId = r.Id
   JOIN Hotels AS h ON b.HotelId = h.Id
GROUP BY b.HotelId, h.[Name]
HAVING b.HotelId IN (
                    SELECT hr.HotelId
					  FROM HotelsRooms AS hr
					  JOIN Rooms AS r ON hr.RoomId = r.Id
					 WHERE r.[Type] = 'VIP Apartment'
					)
ORDER BY COUNT(*) DESC


--EX7
SELECT t.Id
     , t.[Name]
	 , t.PhoneNumber
  FROM Tourists AS t
  LEFT JOIN Bookings AS b ON t.Id = b.TouristId
 WHERE b.Id IS NULL
 ORDER BY t.[Name]



--EX8
SELECT Id
  FROM Hotels
 WHERE (Id % 2) = 1;

SELECT TOP(10)
       h.[Name] AS HotelName
     , d.[Name] AS DestinationName
	 , c.[Name] AS CountryName
  FROM Bookings AS b
  JOIN Hotels AS h ON b.HotelId = h.Id
  JOIN Destinations AS d ON h.DestinationId = d.Id
  JOIN Countries AS c ON d.CountryId = c.Id
 WHERE b.ArrivalDate < '2023-12-31'
   AND b.HotelId % 2 = 1
ORDER BY c.[Name] ASC, b.ArrivalDate ASC

SELECT TOP(10)
       h.[Name] AS HotelName
     , d.[Name] AS DestinationName
	 , c.[Name] AS CountryName
  FROM Bookings AS b
  JOIN Hotels AS h ON b.HotelId = h.Id
  JOIN Destinations AS d ON h.DestinationId = d.Id
  JOIN Countries AS c ON d.CountryId = c.Id
 WHERE b.ArrivalDate < '2023-12-31'
   AND b.HotelId IN (
                    SELECT hh.Id
                    FROM Hotels AS hh
                    WHERE (hh.Id % 2) = 1
					)
ORDER BY c.[Name] ASC, b.ArrivalDate ASC

--for testing
SELECT *
  FROM Bookings AS b
  JOIN Hotels AS h ON b.HotelId = h.Id
  JOIN Destinations AS d ON h.DestinationId = d.Id
  JOIN Countries AS c ON d.CountryId = c.Id
 WHERE h.[Name] IN ('Cavo Tagoo', 'Nautilus Dome')

--EX9
SELECT h.[Name] AS HotelName
     , r.Price AS RoomPrice
  FROM Bookings AS b
  JOIN Tourists AS t ON b.TouristId = t.Id
  JOIN Hotels AS h ON b.HotelId = h.Id
  JOIN Rooms AS r ON b.RoomId = r.Id
 WHERE RIGHT(t.[Name], 2) <> 'EZ'
ORDER BY r.Price DESC



--EX10
SELECT dt.[Name] AS HotelName
     , SUM(dt.TotalPrice) AS HoterRevenue
  FROM
	(SELECT h.[Name]
	     , r.Price
		 , DATEDIFF(DAY, b.ArrivalDate, b.DepartureDate) AS NightsCount
		 , (r.Price * DATEDIFF(DAY, b.ArrivalDate, b.DepartureDate)) AS TotalPrice
	  FROM Bookings AS b
	  JOIN Hotels AS h ON b.HotelId = h.Id
	  JOIN Rooms AS r ON b.RoomId = r.Id) AS dt
GROUP BY dt.[Name]
ORDER BY SUM(dt.TotalPrice) DESC





--SECTION 4 - FUNCTIONS AND STORED PROCEURES - 20pts

--EX11
GO
CREATE OR ALTER FUNCTION udf_RoomsWithTourists(@name VARCHAR(40))
RETURNS INT
AS
BEGIN
	DECLARE @result INT
	SET @result = (SELECT (SUM(b.AdultsCount) + SUM(b.ChildrenCount))
	  FROM Bookings AS b
	  JOIN Tourists AS t ON b.TouristId = t.Id
	  JOIN Rooms AS r ON b.RoomId = r.Id
	 WHERE r.[Type] = @name
	 GROUP BY b.RoomId
	 )
	RETURN @result
END
GO
SELECT dbo.udf_RoomsWithTourists('Double Room')


--EX12
GO
CREATE PROC usp_SearchByCountry(@country NVARCHAR(50)) 
AS
	SELECT t.[Name]
	     , t.PhoneNumber
		 , t.Email
		 , COUNT(*) AS CountOfBookings
	  FROM Tourists AS t
	  LEFT JOIN Bookings AS b ON t.Id = b.TouristId
	  JOIN Countries AS c ON t.CountryId = c.Id
	  WHERE c.[Name] = @country
	  GROUP BY t.[Name], t.PhoneNumber, t.Email
	  ORDER BY t.[Name], COUNT(*) DESC

GO
EXEC usp_SearchByCountry 'Greece'

