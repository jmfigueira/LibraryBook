CREATE DATABASE LibraryBook;
GO
USE LibraryBook;
GO
CREATE TABLE Book
(
	[Id] INT IDENTITY  PRIMARY KEY,
	[Title] VARCHAR(150) NOT NULL,
	[Description] VARCHAR(255) NOT NULL,
	[Author] VARCHAR (150) NOT NULL,
	[Tradutor] VARCHAR(150),
	[Launch] DateTime NOT NULL,
	[Price] FLOAT,
	[Language] VARCHAR(2) NOT NULL,
	[PublishingCompany] VARCHAR(200),
	[Width] FLOAT,
	[Height] FLOAT,
)