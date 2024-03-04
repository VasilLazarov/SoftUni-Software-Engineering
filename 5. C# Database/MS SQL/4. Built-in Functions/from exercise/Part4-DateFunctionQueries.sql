USE Orders
GO

--EX18
SELECT ProductName
     , OrderDate
     , DATEADD(DAY, 3, OrderDate)
	AS [Pay Due]
	 , DATEADD(MONTH, 1, OrderDate)
	AS [Deliver Due]
  FROM Orders


--EX19
USE MyFirstDB
GO

CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL
)
GO
INSERT INTO [People]
	VALUES
		('Vasil', '2000-09-24'),
		('Ani', '2004-05-25'),
		('Victor', '2000-12-07'),
		('Steven', '1992-09-10')
GO
SELECT [Name]
     , DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years]
	 , DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months]
	 , DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days]
	 , DATEDIFF(HOUR, Birthdate, GETDATE()) AS [Age in Hours]
	 , DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
  FROM People









