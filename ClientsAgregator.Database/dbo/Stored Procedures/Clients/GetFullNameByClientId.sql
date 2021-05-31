CREATE PROCEDURE GetFullNameByClientId
AS
SELECT [dbo].[Clients].[LastName], 
[dbo].[Clients].[FirstName], [dbo].[Clients].[MiddleName]
FROM [dbo].[Clients]