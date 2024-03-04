USE [Geography]
GO

--TESTING
SELECT CountryName
     , LEN(REPLACE([CountryName], 'A', ''))
  FROM Countries 

--EX12
SELECT CountryName AS [Country Name]
     , IsoCode AS [ISO Code]
  FROM Countries 
 --WHERE CountryName LIKE '%A%A%A%'
 WHERE LEN(CountryName) - LEN(REPLACE([CountryName], 'A', '')) >= 3
ORDER BY IsoCode


--EX13
SELECT p.PeakName
	 , r.RiverName
	 , LOWER(CONCAT(SUBSTRING(p.PeakName, 1, LEN(p.PeakName) - 1), r.RiverName)) AS [Mix]
  FROM Peaks AS [p],
       Rivers AS [r]
 WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix








