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
