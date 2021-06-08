CREATE PROCEDURE GetClientsFullName
AS
SELECT [dbo].[Clients].[Id], [dbo].[Clients].[LastName], 
[dbo].[Clients].[FirstName], [dbo].[Clients].[MiddleName]
FROM [dbo].[Clients]