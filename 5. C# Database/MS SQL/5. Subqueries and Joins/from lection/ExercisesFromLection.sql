USE SoftUni
GO

--EX2 FROM EXERXISES - FROM LECTION Problem - Addresses with Towns
  SELECT TOP(50)
         e.FirstName
       , e.LastName
	   , t.[Name] AS [Town]
	   , a.AddressText
    FROM Employees AS [e]
    JOIN Addresses AS [a] ON e.AddressID = a.AddressID
    JOIN Towns AS [t] ON a.TownID = t.TownID
ORDER BY FirstName
       , LastName

--EX3 FROM EXERCISES - FROM LECTION Problem - Sales Employees
  SELECT e.EmployeeID
       , e.FirstName
	   , e.LastName
	   , d.[Name] AS [DepartmentName]
    FROM Employees AS [e]
    JOIN Departments AS [d] ON e.DepartmentID = d.DepartmentID
   WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID

--EX6 FROM EXERCISES - FROM LECTION PROBLEM - EMPLOYEES HIRED AFTER
  SELECT e.FirstName
       , e.LastName
	   , e.HireDate
	   , d.[Name] AS [DeptName]
    FROM Employees AS [e]
	JOIN Departments AS [d] 
	  ON (e.DepartmentID = d.DepartmentID
	     AND e.HireDate > '1/1/1999'
		 AND d.[Name] IN ('Sales', 'Finance'))
ORDER BY e.HireDate 

--EX10 FROM EXERCISES - FROM LECTION - PROBLEM EMPLOYEE SUMMARY
  SELECT TOP(50)
         e.EmployeeID
       , CONCAT(e.FirstName, ' ', e.LastName) AS [EmployeeName]
	   , CONCAT(m.FirstName, ' ', m.LastName) AS [ManagerName]
	   , d.[Name] AS [DepartmentName]
    FROM Employees AS [e]
	JOIN Departments AS [d] ON e.DepartmentID = d.DepartmentID
	LEFT JOIN Employees AS [m] ON e.ManagerID = m.EmployeeID
ORDER BY e.EmployeeID



--SUBQUERIES

--Problem - Min Average Salary
--METHOD 1
SELECT TOP(1)
       AVG(e.Salary) AS [AverageSalary]
  FROM Employees AS [e]
GROUP BY e.DepartmentID
ORDER BY AverageSalary
--METHOD 2
SELECT MIN(dt.AverageSalary)
  FROM  (SELECT e.DepartmentID
              , AVG(e.Salary) AS [AverageSalary]
           FROM Employees AS [e]
       GROUP BY e.DepartmentID) AS dt




--EX15 FROM EXERCISES
USE Geography
GO

--FIRST WAY
  SELECT co.ContinentCode
       , co.CurrencyCode
	   , COUNT(co.CountryCode)
    FROM Countries AS [co]
GROUP BY co.ContinentCode, co.CurrencyCode
HAVING COUNT(co.CountryCode) > 1
   and count(*) = (select top 1 count(*)
                   from Countries as csq
                   where csq.ContinentCode = co.ContinentCode
                   group by csq.ContinentCode, csq.CurrencyCode
                   order by count(*) DESC)
ORDER BY ContinentCode

--SECOND WAY
SELECT dt.ContinentCode
     , dt.CurrencyCode
	 , dt.CurrencyUsage
  FROM
(SELECT co.ContinentCode
       , co.CurrencyCode
	   , COUNT(co.CountryCode) AS CurrencyUsage
	   , DENSE_RANK() OVER 
	                  (
					  PARTITION BY co.ContinentCode
					  ORDER BY COUNT(co.CountryCode) DESC
					  ) AS [DenseRank]
    FROM Countries AS [co]
GROUP BY co.ContinentCode, co.CurrencyCode
HAVING COUNT(co.CountryCode) > 1) AS dt
WHERE dt.DenseRank = 1
ORDER BY ContinentCode







--MY TESTS
SELECT e.DepartmentID
     , e.Salary
     , AVG(e.Salary) AS [AverageSalary]
  FROM Employees AS [e]
GROUP BY e.Salary, e.DepartmentID
--GROUP BY e.DepartmentID, e.Salary

SELECT ManagerID
	 , FirstName
  FROM Employees AS e
 --WHERE DepartmentID = 1
GROUP BY FirstName, ManagerID
--GROUP BY ManagerID,  FirstName

SELECT *
FROM Employees
ORDER BY FirstName

  SELECT
         CONCAT(c.FirstName, ' ', c.LastName) AS FullName
		 --c.FirstName
		,  c.ManagerID
    FROM Employees AS c
--GROUP BY c.FirstName, c.LastName, c.ManagerID
GROUP BY c.ManagerID, c.FirstName, c.LastName
--HAVING RIGHT (c.Email, 4) = '.com'
ORDER BY FullName




