USE SoftUni
GO

-----------------------------------------------
--Test - Define Variable
DECLARE @separator CHAR = ' ';
--SET @separator = ' ';
--test CONCAT with separator variable - WORK BUT MUST BE EXECUTE WITH CREATING OF VARIABLE
SELECT CONCAT(FirstName, @separator, MiddleName, @separator, LastName)
  FROM Employees
 WHERE EmployeeID < 7

-----------------------------------------------

--Concatenation
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName)
  FROM Employees
 WHERE EmployeeID < 7

SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName)
  FROM Employees
 WHERE EmployeeID < 7


--Substring
SELECT SUBSTRING(FirstName, 1, 1)
  FROM Employees
 WHERE EmployeeID < 7

SELECT CONCAT(SUBSTRING(FirstName, 1, 3), '...')
  FROM Employees
 WHERE EmployeeID < 7


--Replace - REPLACE(String, Pattern, Replacement)
SELECT REPLACE('SoftUni', 'Soft', 'Hard') 
--censor example
SELECT REPLACE('I am gay, I am guy, I am gay', 'gay', '***') -- STRING CAN BE TEXT FROM ANY TABLE


--Trim - for left trim LTRIM, for right trim RTRIM, or TRIM for 2 sides - REMOVE SPACES BEFORE AND AFTER TEXT
SELECT TRIM(' ' + ' ' + ' ' + 'Vasil Lazarov' + ' ' + ' ' + ' ')


--Len - with LEN
SELECT LEN('Vasil Lazarov') -- 13 symbols
SELECT LEN('Vasil Lazarov             ') -- 13 symbols - because LEN remove spaces in the end of text
SELECT LEN('  Vasil Lazarov') -- 15 symbols - LEN dont remove spaces before text


--DATALENGTH - GET NUMBERS OF USED BYTES
SELECT DATALENGTH('Horse');
SELECT DATALENGTH('Кон');


-- LEFT & RIGHT - get charakters from begginning or the end of string
SELECT LEFT('VASIL LAZAROV', 3)
SELECT RIGHT('VASIL LAZAROV', 3)


--LOWER & UPPER
SELECT LOWER('Vasil LAZAROV')
SELECT UPPER('Vasil lazarov')


--REVERSE - reverse order of all charakters
SELECT REVERSE('Vasil Lazarov')
SELECT REVERSE('vorazaL lisaV')


-- REPLICATE - repeats a string
SELECT REPLICATE('I am ', 7)
SELECT REPLACE('I am gay, I am guy, I am gay', 'gay', REPLICATE('*', LEN('gay')))
SELECT REPLICATE('*', LEN(FirstName))
  FROM Employees
 WHERE EmployeeID < 7


--FORMAT - format a value with valid .NET format string
         -- WORK ONLY WITH MSSQL AND .NET
-- DA PROVERQ V NETA KAK SE PRAVI


--EXERCISE 1 
USE Demo
GO
CREATE VIEW v_PublicPaymentInfo AS
SELECT CustomerID AS ID
     , FirstName
	 , LastName
	 , CONCAT(LEFT(PaymentNumber, 6), REPLICATE('*', (LEN(PaymentNumber) - 6))) AS [PaymentNumber]
  FROM Customers
GO
SELECT * FROM v_PublicPaymentInfo


-- CHARINDEX - locates a specific pattern(substring) in string - and return index of first charakter - optional we can gift third parament from which index start searching
SELECT CHARINDEX('CDE', 'ABCDEFG')


--STUFF - insert a substring at a specific position
SELECT STUFF()


SELECT * FROM Employees



















