USE SoftUni
GO

--DEMOS
--demo1
  SELECT d.[Name] AS DepartmentName
       , MIN(e.Salary) AS MinSalary
	   , MAX(e.Salary) AS MaxSalary
	   , AVG(e.Salary) AS AvgSalary
    FROM Employees AS e
    JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, d.[Name]


--PROBLEM - DEPARTMENTS TOTAL SALARIES
  SELECT e.DepartmentID
       , SUM(e.Salary) AS TotalSalary
    FROM Employees AS [e]
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

SELECT *
  FROM Employees
 WHERE DepartmentID = 1

--DEMO FOR COUNT - COUNT SKIP NULL VALUES!!!
SELECT
       COUNT(MiddleName)
  FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

SELECT
       COUNT(*)
  FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID


--FIND HOW MANY PEOPLE DONT HAVE MIDDLE NAME
SELECT
       COUNT(*) - COUNT(MiddleName) AS NumberOfPeopleWithoutMiddleName
  FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID


--FUNCTION - STRING_AGG
  SELECT DepartmentID
       , STRING_AGG(CONCAT_WS(' ', FirstName, LastName), ', ')
	     WITHIN GROUP (ORDER BY FirstName, LastName) AS [AllEmployeesInDepartment]
    FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID


--HAVING - CAN USE ONLY AFTER GROUP BY
--DEMOS
  SELECT DepartmentID
       , COUNT(*) AS NumberOfEmployees
    FROM Employees
GROUP BY DepartmentID
HAVING COUNT(*) >= 10
ORDER BY NumberOfEmployees DESC

--PROBLEM - HAVING CLAUSE: EXAMPLE
  SELECT d.[Name]
       , SUM(e.Salary) AS TotalSalary
    FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
  HAVING SUM(e.Salary) >= 122800
ORDER BY TotalSalary
