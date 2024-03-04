USE SoftUni
GO

--CAST & CONVERT - conversion between data types
SELECT CAST('2023' AS INT)
SELECT CAST('2023' AS DECIMAL)


--ISNULL - swaps NULL values with a specified default value
SELECT ISNULL(NULL, 'NOT NULL')
--EXERCISE - display "Not Finished" for projects with no EndDate
--ISNULL WORKING ONLY IN MSSQL
SELECT ProjectID
     , [Name]
	 --, EndDate
	 , ISNULL(CAST(EndDate AS varchar), 'Not Finished') AS [ENDDATE]
  FROM Projects


--COALESCE - SAME AND ISNULL - WORK ON MSSQL AND OTHER SQL-s
SELECT ProjectID
     , [Name]
	 --, EndDate
	 , COALESCE(CAST(EndDate AS varchar), 'Not Finished') AS [ENDDATE]
  FROM Projects


--OFFSET & FETCH - get only specific rows from the result set
SELECT *
  FROM Employees
ORDER BY FirstName--EmployeeID
OFFSET 4 ROWS
 FETCH NEXT 6 ROWS ONLY

SELECT *
  FROM Employees
ORDER BY FirstName--EmployeeID
OFFSET 10 * (1 - 1) ROWS
 FETCH NEXT 10 ROWS ONLY

SELECT *
  FROM Employees
ORDER BY FirstName--EmployeeID
OFFSET 10 * (2 - 1) ROWS
 FETCH NEXT 10 ROWS ONLY

