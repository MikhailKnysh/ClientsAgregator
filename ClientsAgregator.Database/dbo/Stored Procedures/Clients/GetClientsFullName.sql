CREATE PROCEDURE [ClientsAgregatorDB].[GetClientsFullName]
AS
SELECT [ClientsAgregatorDB].[Clients].[Id], [ClientsAgregatorDB].[Clients].[LastName], 
[ClientsAgregatorDB].[Clients].[FirstName], [ClientsAgregatorDB].[Clients].[MiddleName]
FROM [ClientsAgregatorDB].[Clients]