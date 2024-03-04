USE SoftUni
GO

--TESTING



--EX1
SELECT FirstName
     , LastName
  FROM Employees
 --WHERE FirstName LIKE 'Sa%'
 WHERE LEFT([FirstName], 2) = 'Sa'


--EX2
SELECT FirstName
     , LastName
  FROM Employees
 --WHERE LastName LIKE '%ei%'   -- METHOD 1
 WHERE CHARINDEX('ei', LastName) > 0  -- METHOD 2


--EX3
SELECT FirstName
     --, HireDate
  FROM Employees
 WHERE DepartmentID IN (3, 10)
   AND YEAR(HireDate) BETWEEN 1995 AND 2005
   --AND FORMAT(HireDate, 'yyyy', 'bg-BG') BETWEEN 1995 AND 2005
   --AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005


--EX4
SELECT FirstName
     , LastName
  FROM Employees
 --WHERE CHARINDEX('engineer', JobTitle) = 0
 WHERE JobTitle NOT LIKE '%engineer%'


--EX5
SELECT [Name]
  FROM Towns
 WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]


--EX6
SELECT *
  FROM Towns
 WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
 --WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]


--EX7
SELECT *
  FROM Towns
 WHERE LEFT([Name], 1) NOT IN ('R', 'D', 'B')
 --WHERE [Name] NOT LIKE '[RDB]%'
ORDER BY [Name]


--EX8
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName
     , LastName
  FROM Employees
 WHERE YEAR(HireDate) > 2000
GO
SELECT * FROM V_EmployeesHiredAfter2000


--EX9
SELECT FirstName
     , LastName
  FROM Employees
 WHERE LEN(LastName) = 5


--EX10
SELECT EmployeeID
     , FirstName
	 , LastName
	 , Salary
	 , DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [DenseRank]
  FROM Employees
 WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC


--EX11
SELECT *
  FROM(
       SELECT EmployeeID
            , FirstName
       	 , LastName
       	 , Salary
       	 , DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [DenseRank]
         FROM Employees
        WHERE Salary BETWEEN 10000 AND 50000
	  ) AS [RankingSubquery]
WHERE DenseRank = 2
ORDER BY Salary DESC



