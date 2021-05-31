CREATE PROCEDURE GetFullNameAndContactInfoByClientId
@ClientId INT
AS
SELECT [dbo].[Clients].[LastName], 
[dbo].[Clients].[FirstName], [dbo].[Clients].[MiddleName],
[dbo].[Clients].[Email], [dbo].[Clients].[Phone]
FROM [dbo].[Clients]
WhERE [dbo].[Clients].[Id] = @ClientId