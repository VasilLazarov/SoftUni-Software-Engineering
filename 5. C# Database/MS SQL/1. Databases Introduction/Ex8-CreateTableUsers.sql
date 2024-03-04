USE [Minions]

--EXERCISE 8
CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] VARCHAR(5)
)

INSERT INTO [Users] ([Username], [Password], [LastLoginTime], [IsDeleted])
	VALUES
	('vasil17', 'pass1111', GETDATE(), 'false'),
	('anelia69', 'pass6969', GETDATE(), 'false'),
	('marto33', 'pass3333', GETDATE(), 'false'),
	('ivailo45', 'pass5555', GETDATE(), 'false'),
	('random', 'pass0000', GETDATE(), 'true')

--EXERCISE 9
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC070947B4FE]

ALTER TABLE [Users]
ADD CONSTRAINT [PK__Users__IdAndUsername] PRIMARY KEY([Id], [Username])


--BEFORE EX10 DELETE ENTITY WITH PASSWORD < 5
DELETE FROM [Users] WHERE LEN([Password]) < 5

--EXERCISE 10
ALTER TABLE [Users]
ADD CONSTRAINT [CHK_Password_Min_Length] CHECK (LEN([Password]) >= 5)

--EXERCISE 11
ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime] DEFAULT GETDATE() FOR [LastLoginTime]

--EXERCISE 12
ALTER TABLE [Users]
	DROP CONSTRAINT [PK__Users__IdAndUsername]
ALTER TABLE [Users]
	ADD CONSTRAINT [PK__Users__Id] PRIMARY KEY([Id])
ALTER TABLE [Users]
	ADD CONSTRAINT [Users__Username__Unique] UNIQUE([Username])
ALTER TABLE [Users]
	ADD CONSTRAINT [CK__Users__Username__Len] CHECK (LEN([Username]) >= 3)


