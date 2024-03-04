SELECT FirstName, LastName, Salary FROM Employees

SELECT * FROM Employees

SELECT FirstName, LastName, Salary FROM Employees WHERE DepartmentID = 1

SELECT 
	FirstName AS [Име]
	, LastName AS [Фамилия]
	, Salary AS [Заплата]
	, d.[Name] AS [Отдел]
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.DepartmentID = 1
ORDER BY Salary DESC

SELECT 
--	FirstName + ' ' + LastName AS [Име и фамилия]
--	CONCAT(FirstName, ' ', LastName) AS [Име и Фамилия]
	CONCAT_WS(' ', FirstName, MiddleName ,LastName) AS [Име и Фамилия]
	, Salary AS [Заплата]
	, d.[Name] AS [Отдел]
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.DepartmentID = 1
ORDER BY Salary DESC


SELECT 
--	FirstName + ' ' + LastName AS [Име и фамилия]
--	CONCAT(FirstName, ' ', LastName) AS [Име и Фамилия]
	CONCAT_WS(' ', FirstName, MiddleName ,LastName) AS [Име и Фамилия]
	, Salary AS [Заплата]
	, d.[Name] AS [Отдел]
	,t.[Name] AS [Град]
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE e.DepartmentID = 1
ORDER BY Salary DESC


SELECT
	CONCAT_WS(' ', FirstName, LastName) AS [Full Name]
	,JobTitle
	,Salary
FROM Employees


SELECT DISTINCT DepartmentID FROM Employees

SELECT DISTINCT DepartmentID, ManagerID FROM Employees

SELECT LastName, Salary FROM Employees
WHERE Salary <= 20000

SELECT LastName, Salary FROM Employees
WHERE Salary <= 20000
ORDER BY Salary DESC

SELECT LastName, Salary FROM Employees
WHERE Salary BETWEEN 18000 AND 20000
ORDER BY Salary DESC

SELECT FirstName, LastName, ManagerID 
FROM Employees
WHERE ManagerID IN (109, 3, 16)


--NULL - HOW WORKS -> NULL = MISSING VALUE
SELECT * FROM Employees WHERE MiddleName = NULL --DONT WORK!!!
SELECT * FROM Employees WHERE MiddleName IS NULL --USE KEY WORD "IS" AND QUERY WORKING
SELECT * FROM Employees WHERE MiddleName IS NOT NULL



SELECT 
	CONCAT_WS(' ', FirstName, MiddleName ,LastName) AS [Име и Фамилия]
	, Salary AS [Заплата]
	, d.[Name] AS [Отдел]
	,t.[Name] AS [Град]
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE e.DepartmentID = 1
ORDER BY Salary DESC, CONCAT_WS(' ', FirstName, MiddleName ,LastName)




GO
CREATE VIEW v_EngineeringEmployeesBySalary AS SELECT 
	CONCAT_WS(' ', FirstName, MiddleName ,LastName) AS [Име и Фамилия]
	, Salary AS [Заплата]
	, d.[Name] AS [Отдел]
	,t.[Name] AS [Град]
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE e.DepartmentID = 1
GO
SELECT * FROM v_EngineeringEmployeesBySalary
ORDER BY [Заплата] DESC, [Име и Фамилия]





--Inserting data
INSERT INTO Departments([Name], [ManagerID])
	VALUES 
	('HR', 7)


SELECT 
	FirstName
	, LastName
	, Salary 
INTO [EngineeringDepartmentList]
FROM Employees
WHERE DepartmentID = 1



-- Deleting data - DON'T FORGET WHERE
DELETE FROM Departments WHERE [Name] = 'HR' --Delete specific rows
TRUNCATE TABLE EngineeringDepartmentList --Delete all rows from table
DROP TABLE EngineeringDepartmentList --Delete table


--Updating data
UPDATE Departments
SET [Name] = 'HRR'
WHERE [Name] = 'HR' -- USUALLY UPDATE FROM ID

UPDATE Departments
SET [Name] = 'HR',
	[ManagerID] = 77
WHERE DepartmentID = 19

--Problem: Update Projects
SELECT * FROM Projects
WHERE EndDate IS NULL

BEGIN TRANSACTION;
UPDATE Projects
SET EndDate = GETDATE()
WHERE EndDate IS NULL

SELECT * FROM Projects
WHERE EndDate > '2023-09-25'

ROLLBACK;
COMMIT; -- FOR SAVE CHANGES

--Without rollback we can return like that:
UPDATE Projects
SET EndDate = NULL
WHERE EndDate > '2023-09-25'

