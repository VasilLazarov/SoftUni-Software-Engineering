USE SoftUni
GO

--User-Defined Functions

--BUILT-IN FUNCTIONS
SELECT AVG(Salary) AS [AVG]
     , MAX(Salary) AS [MAX]
	 , MIN(Salary) AS [MIN]
  FROM Employees


--HOW TO DEFINE CUSTOM FUNCTION

--SCALAR FUNCTIONS
--EXAMPLE - FUNCTION WHICH RETURN PROJECT  DURATION IN WEEKS
GO
CREATE OR ALTER FUNCTION udf_ProjectDurationWeeks(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS 
BEGIN
	DECLARE @projectWeeks INT;
	IF(@EndDate IS NULL)
	BEGIN
		SET @EndDate = GETDATE()
	END
	SET @projectWeeks = DATEDIFF(WEEK, @StartDate, @EndDate)
	RETURN @projectWeeks;
END
GO
SELECT [Name]
	 , [Description]
	 , dbo.udf_ProjectDurationWeeks(StartDate, EndDate) AS [DurationInWeeks]
FROM Projects



--TVF - TABLE-VALUED FUNCTION
--EXAMPLE - AVERAGE SALARY BY DEPARTMENT
GO
CREATE OR ALTER FUNCTION udf_AverageSalaryByDepartment()
RETURNS TABLE AS
RETURN(
	  SELECT d.[Name] AS Department
	       , AVG(e.Salary) AS AverageSalary
	    FROM Departments AS d
		JOIN Employees AS e ON d.DepartmentID = e.DepartmentID
	GROUP BY d.DepartmentID, d.[Name]
)
GO
SELECT * FROM dbo.udf_AverageSalaryByDepartment()

GO
CREATE OR ALTER FUNCTION udf_AverageSalaryByDepartmentWithMin(@MinimumSalary INT)
RETURNS TABLE AS
RETURN(
	  SELECT d.[Name] AS Department
	       , AVG(e.Salary) AS AverageSalary
	    FROM Departments AS d
		JOIN Employees AS e ON d.DepartmentID = e.DepartmentID
	GROUP BY d.DepartmentID, d.[Name]
	  HAVING AVG(e.Salary) > @MinimumSalary
)
GO
SELECT * FROM dbo.udf_AverageSalaryByDepartmentWithMin(40000)



--STORED PROCEDURES

--HOW TO CREATE AND RUN PROCEDURE

--CREATE STORED PROCEDURE WITHOUT PARAMETERS
GO
CREATE OR ALTER PROC usp_selectEmployeesBySeniority
AS
	SELECT EmployeeID
	     , FirstName
	  FROM Employees
	  WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > 20
GO
EXEC usp_selectEmployeesBySeniority

--ADD IN TABLE WITH STORE PROCEDURE
CREATE TABLE Customers(
	[EmployeeID] INT,
	[FirstName] VARCHAR(20)
)
INSERT INTO Customers
EXEC usp_selectEmployeesBySeniority

SELECT * FROM Customers

EXEC sp_depends 'usp_selectEmployeesBySeniority' --CAN USE ALSO WITHOUT SINGLE QUOTES


--CREATE STORED PROCEDURE WITH PARAMETERS
GO
CREATE PROC usp_SelectEmployeesBySeniorityWithParameter
	  (@minYearsAtWork INT = 5)
AS
  SELECT FirstName
       , LastName
	   , HireDate
	   , DATEDIFF(YEAR, HireDate, GETDATE()) AS Years
    FROM Employees
   WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @minYearsAtWork
ORDER BY HireDate

GO
--TYPES OF EXEC WITH PARAMS
--FIRST WAY - EXEC PROC_NAME PARAM1_VALUE, PARAM2_VALUE.....
EXEC usp_SelectEmployeesBySeniorityWithParameter 22
--SECOND WAY - EXEC PROC_NAME
--				 @PARAM1 = VALUE
--               @PARAM2 = VALUE
--               .......
EXEC usp_SelectEmployeesBySeniorityWithParameter
	@minYearsAtWork = 22

--RETURNING VALUES USING OUTPUT PARAMS
GO
CREATE PROC usp_SumOfTwoNumbers
	@firstNumber SMALLINT,
	@secondNumber SMALLINT,
	@result INT OUTPUT
AS
	SET @result = @firstNumber + @secondNumber
GO
DECLARE @answer INT
EXECUTE usp_SumOfTwoNumbers 7, 8, @answer OUTPUT
SELECT 'The result is: ', @answer
--SAME PROC WITHOUT OUTPUT PARAM
GO
CREATE OR ALTER PROC usp_SumOfTwoNumbers_WithoutParameter
	@firstNumber INT,
	@secondNumber INT
AS
	SELECT 'The result is: ', @firstNumber + @secondNumber
GO
EXEC usp_SumOfTwoNumbers_WithoutParameter 7, 8

--PROCEDURE WHICH RETURN MULTIPLE RESULTS
GO
CREATE OR ALTER PROC usp_MultipleResult
AS
	SELECT * 
	  FROM Employees
	SELECT e.FirstName
	     , e.LastName
		 , d.DepartmentID
	  FROM Employees AS e
      JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GO
EXEC usp_MultipleResult



--ERROR HANDLING
--EXAMPLE
GO
CREATE OR ALTER PROC usp_ErrorTest
AS
BEGIN TRY
	-- Generate a divide-by-zero error.
	SELECT 1/0
END TRY
BEGIN CATCH
	SELECT
		   ERROR_NUMBER() AS ErrorNumber
		 , ERROR_SEVERITY() AS ErrorSeverity
		 , ERROR_STATE() AS ErrorState
		 , ERROR_PROCEDURE() AS ErrorProcedure
		 , ERROR_LINE() AS ErrorLine
		 , ERROR_MESSAGE() AS ErrorMessage;
END CATCH
GO
SELECT @@ERROR
EXEC usp_ErrorTest















--OTHER
SELECT
 	[DepartmentID],
	MAX([Salary]) AS [ThirdHighestSalary]
FROM
(
	SELECT 
		[DepartmentID],
		[Salary],
		DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [Rank]
	FROM [Employees]
) AS [t]
WHERE [Rank] = 3
GROUP BY [DepartmentID]


--EX19 FROM INDICES AND DATA AGREDATION EXERCISE
--MINE IDEA
SELECT TOP(10)
       FirstName
     , LastName
	 , DepartmentID
  FROM Employees AS e
 WHERE Salary > (
		  SELECT AVG(Salary)
            FROM Employees AS em
		GROUP BY DepartmentID
		HAVING em.DepartmentID = e.DepartmentID)
ORDER BY DepartmentID
GO
--FROM OTHER GUY
SELECT TOP 10
	e.[FirstName],
	e.[LastName],
	e.[DepartmentID]
FROM [Employees] AS [e]
JOIN
(
	SELECT
		e.[DepartmentID],
		AVG(e.Salary) AS [AverageSalary]
	FROM [Employees] AS [e]
	GROUP BY e.[DepartmentID]
) AS [AvgTable]
	ON e.[DepartmentID] = AvgTable.[DepartmentID]
WHERE e.[Salary] > AvgTable.[AverageSalary]


GO
SELECT DepartmentID
       , AVG(Salary)
    FROM Employees
GROUP BY DepartmentID