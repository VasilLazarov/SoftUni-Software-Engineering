USE SoftUni
GO

SELECT DepartmentID
     , PERCENTILE_CONT(0.5) 
WITHIN GROUP(ORDER BY Salary DESC) 
  OVER (PARTITION BY DepartmentId)
  FROM Employees









