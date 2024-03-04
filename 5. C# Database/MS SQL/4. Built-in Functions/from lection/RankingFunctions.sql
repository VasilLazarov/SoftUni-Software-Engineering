USE [SoftUni]
GO

SELECT 
	   ROW_NUMBER() OVER (ORDER BY Salary DESC) AS Id
	 , FirstName
	 , LastName
	 , Salary
	 , DENSE_RANK() OVER (ORDER BY Salary DESC) AS [DenseRank]
	 , RANK() OVER (ORDER BY Salary DESC) AS [Rank]
	 , Salary
	 , NTILE(5) OVER (ORDER BY Salary DESC) AS [FiveTile]
	 --, NTILE(5) OVER (ORDER BY FirstName) AS [FiveTile]
  FROM Employees 
 WHERE DepartmentID = 5



  SELECT Salary
       , COUNT(*)
    FROM Employees
   WHERE DepartmentID = 5
GROUP BY Salary



  SELECT DepartmentID
       , Salary
       , COUNT(*)
    FROM Employees
GROUP BY DepartmentID, Salary
ORDER BY DepartmentID





