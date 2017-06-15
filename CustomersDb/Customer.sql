CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerName] NVARCHAR(50) NOT NULL, 
    [CustomerAddress] NVARCHAR(50) NOT NULL, 
    [JoiningDate] DATETIME NOT NULL
)

GO

CREATE INDEX [IX_Customer_JoiningDate] ON [dbo].[Customer] ([JoiningDate])
