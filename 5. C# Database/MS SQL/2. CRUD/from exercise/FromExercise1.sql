USE [SoftUni]

GO

--EXERCISE 2
SELECT * FROM Departments

--EXERCISE 3
SELECT [NaME]
  FROM Departments

--EXERCISE 4
SELECT FirstName
	 , LastName
	 , Salary
  FROM Employees

--EXERCISE 5
SELECT FirstName
	 , MiddleName
	 , LastName
  FROM Employees

--EXERCISE 6
SELECT
       CONCAT(FirstName, '.', LastName, '@', 'softuni.bg') AS [Full Email Address]
  FROM Employees

--EXERCISE 7
SELECT 
DISTINCT Salary
    FROM Employees
ORDER BY Salary --ASC

--EXERCISE 8
SELECT * 
  FROM Employees
 WHERE JobTitle = 'Sales Representative'

--EXERCISE 9
SELECT FirstName
     , LastName
	 , JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
--ORDER BY Salary

--EXERCISE 10
SELECT 
	   CONCAT(FirstName, ' ' + MiddleName, ' ' + LastName)
	   AS [Full Name]
  FROM Employees
 --WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600
 WHERE Salary IN (25000, 14000, 12500, 23600)

--EXERCISE 11
SELECT FirstName
	 , LastName
  FROM Employees
 WHERE ManagerID IS NULL

--EXERCISE 12
SELECT FirstName
     , LastName
	 , Salary
  FROM Employees
 WHERE Salary > 50000
ORDER BY Salary DESC

--EXERCISE 13
SELECT TOP(5)
       FirstName
     , LastName
  FROM Employees
ORDER BY Salary DESC

--EXERCISE 14
SELECT FirstName
     , LastName
  FROM Employees
 WHERE DepartmentID <> 4

 --EXERCISE 15
  SELECT *
    FROM Employees
ORDER BY Salary DESC, 
         FirstName, 
		 LastName DESC, 
		 MiddleName


--EXERCISE 16
GO
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName
     , LastName
	 , Salary
  FROM Employees
GO

--EXERCISE 17
GO
CREATE VIEW V_EmployeeNameJobTitle 
         AS
            (
			  SELECT 
		             CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name]
	               , JobTitle
                FROM Employees
		    )
GO
SELECT * FROM V_EmployeeNameJobTitle

--EXERCISE 18
SELECT DISTINCT JobTitle
  FROM Employees

--EXERCISE 19
SELECT TOP(10) *
  FROM Projects
ORDER BY StartDate,
         [Name]

--EXERCISE 20
SELECT TOP(7)
	   FirstName
	 , LastName
	 , HireDate
  FROM Employees
ORDER BY HireDate DESC

--EXERCISE 21
SELECT * FROM Employees

SELECT * 
  FROM Departments
 WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')

UPDATE Employees
   SET Salary += Salary * 0.12
 WHERE DepartmentID IN (1, 2, 4, 11)

SELECT Salary
  FROM Employees

--EX21 ADVANCED SOLUTION
UPDATE Employees
   SET Salary += Salary * 0.12
 WHERE DepartmentID IN 
					  (
					    SELECT DepartmentID 
                          FROM Departments
                         WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
					  )

GO
--EXERCISE 22
USE [Geography]
GO

SELECT PeakName
  FROM Peaks
ORDER BY PeakName

--EXERCISE 23
SELECT TOP(30)
	   CountryName
	 , Population
  FROM Countries
 WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC,
         [CountryName]

--EXERCISE 24
--CASE WHEN -> If [CurrencyCode] = 'EUR' then display 'EURO'
--             else display 'Not euro'
SELECT CountryName
     , CountryCode
	 --, CurrencyCode
	 , CASE
	        WHEN CurrencyCode = 'EUR' THEN 'Euro'
			ELSE 'Not Euro'
	   END AS [Currency]
  FROM Countries
ORDER BY CountryName

--SECOND WAY FOR CASE WHEN
SELECT CountryName
     , CountryCode
	 --, CurrencyCode
	 , CASE CurrencyCode
	        WHEN 'EUR' THEN 'Euro'
			ELSE 'Not Euro'
	   END AS [Currency]
  FROM Countries
ORDER BY CountryName
GO

--EXERCISE 25
USE Diablo
GO

SELECT [Name]
  FROM Characters
ORDER BY [Name]







