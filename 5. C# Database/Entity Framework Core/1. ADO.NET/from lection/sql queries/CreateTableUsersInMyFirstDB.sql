USE MyFirstDB
GO

CREATE TABLE [Users](
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(150) NOT NULL
)
INSERT INTO Users
VALUES
	('vankata121', 'bd94dcda26fccb4e68d6a31f9b5aac0b571ae266d822620e901ef7ebe3a11d4f')


SELECT Id
  FROM Users
 WHERE Username = 'GFG'
   AND [Password] = 'bd94dcda26fccb4e68d6a31f9b5aac0b571ae266d822620e901ef7ebe3a11d4f'


DECLARE @usernameParam NVARCHAR(50) = 'vankata121'
DECLARE @passwordParam NVARCHAR(150) = 'bd94dcda26fccb4e68d6a31f9b5aac0b571ae266d822620e901ef7ebe3a11d4f'
SELECT Id FROM Users 
WHERE Username = @usernameParam AND [Password] = @passwordParam
