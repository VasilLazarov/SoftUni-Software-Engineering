USE Diablo
GO

--EX14
SELECT TOP(50)
       [Name]
     --, [Start]
	 , FORMAT([Start], 'yyyy-MM-dd', 'bg-BG') AS [Start]
  FROM Games
 WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start], [Name]


--EX15
SELECT [Username]
     , SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) 
	AS [Email Provider]
     --, RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider2]
  FROM [Users]
ORDER BY [Email Provider]
       , [Username]

--TEST
SELECT CHARINDEX('@', Email)
  FROM Users


--EX16
SELECT Username
     , IpAddress
  FROM Users
 WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username


--EX17
SELECT [Name] AS [Game]
     , CASE 
	       WHEN DATEPART(HOUR ,[Start]) >= 0 AND DATEPART(HOUR ,[Start]) < 12 THEN 'Morning'
		   WHEN DATEPART(HOUR ,[Start]) >= 12 AND DATEPART(HOUR ,[Start]) < 18 THEN 'Afternoon'
		   WHEN DATEPART(HOUR ,[Start]) >= 18 AND DATEPART(HOUR ,[Start]) < 24 THEN 'Evening'
	   END AS [Part of the Day]
	 , CASE
	       WHEN [Duration] <= 3 THEN 'Extra Short'
		   WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
		   WHEN [Duration] > 6 THEN 'Long'
		   WHEN [Duration] IS NULL THEN 'Extra Long'
	   END AS [Duration]
  FROM Games
ORDER BY [Game]
       , [Duration]
	   , [Part of the Day]





