﻿CREATE TABLE [dbo].[Ingredients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(20) NULL, 
    [Description] NCHAR(100) NULL, 
    [Unit] NCHAR(10) NULL, 
    [CostPerUnit] DECIMAL NULL, 
    [Callories] INT NULL
)
