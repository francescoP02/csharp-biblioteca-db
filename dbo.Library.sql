CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Surname] VARCHAR(50),
	[Email] VARCHAR(50) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Phone] VARCHAR(50)
)

CREATE TABLE [dbo].[Books]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Isbn] VARCHAR(50) NOT NULL,
	[Title] VARCHAR(50),
	[Pages] INT,
	[Year] INT,
	[Genre] VARCHAR(50),
	[Available] TINYINT,
	[Shelf] VARCHAR(50),
	[Author] VARCHAR(50)
)

CREATE TABLE [dbo].[DVDs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[SerialNumber] VARCHAR(50) NOT NULL,
	[Time] INT,
	[Title] VARCHAR(50),
	[Year] INT,
	[Genre] VARCHAR(50),
	[Available] TINYINT,
	[Shelf] VARCHAR(50),
	[Author] VARCHAR(50)
)
