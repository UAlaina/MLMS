﻿CREATE TABLE [dbo].[Book]
(
	[BookId] INT NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(255) NOT NULL,
    [ISBN] NVARCHAR(13) UNIQUE NOT NULL,
	[Author] NVARCHAR(255) NOT NULL,
    [YearPublished] INT NULL,
    Descriptions TEXT NULL,
);
