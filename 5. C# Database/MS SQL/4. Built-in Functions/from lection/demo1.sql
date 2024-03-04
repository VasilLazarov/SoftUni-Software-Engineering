USE SoftUni
GO

SELECT COUNT(*)
  FROM Employees
 WHERE DepartmentID = 7


SELECT DepartmentID 
     , COUNT(*) AS [CountT]
  FROM Employees
GROUP BY DepartmentID
ORDER BY CountT DESC   --ORDER BY DepartmentID

--GET ONLY DEPARTMENTS WITH MORE THAN 8 EMPLOYEES
--FIRST WAY - NOT BETTER
SELECT * FROM
( SELECT DepartmentID 
       , COUNT(*) AS [CountT]
    FROM Employees
  GROUP BY DepartmentID
) AS DT
 WHERE DT.CountT > 8
 ORDER BY DT.CountT DESC
--SECOND WAY - BETTER
  SELECT DepartmentID 
       , COUNT(*) AS [CountT]
    FROM Employees
GROUP BY DepartmentID
  HAVING COUNT(*) > 8
ORDER BY CountT DESC









