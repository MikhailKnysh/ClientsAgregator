CREATE PROCEDURE [ClientsAgregatorDB].[GetFullNameAndContactInfoByClientId]
@ClientId INT
AS
SELECT [ClientsAgregatorDB].[Clients].[LastName], 
[ClientsAgregatorDB].[Clients].[FirstName], [ClientsAgregatorDB].[Clients].[MiddleName],
[ClientsAgregatorDB].[Clients].[Email], [ClientsAgregatorDB].[Clients].[Phone]
FROM [ClientsAgregatorDB].[Clients]
WhERE [ClientsAgregatorDB].[Clients].[Id] = @ClientId