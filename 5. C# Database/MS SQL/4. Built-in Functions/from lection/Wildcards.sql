USE SoftUni
GO

--WILDCARDS - WORK SLOW, DONT USE(IF CAN USE OTHER FUNCTIONS FOR DO SEARCHING)
SELECT *
  FROM Employees
 WHERE FirstName LIKE 'Ro%' 

SELECT *
  FROM Employees
 WHERE FirstName LIKE '%Ro%' 

--ESCAPE - specify prefix to treat special charakters as normal
--SELECT ID, Name
-- FROM Tracks
--WHERE Name LIKE '%max!%' ESCAPE '!'




















