CREATE PROCEDURE [ClientsAgregatorDB].[GetOrdersInfo]
AS
SELECT [ClientsAgregatorDB].[Orders].[Id], [ClientsAgregatorDB].[Orders].[OrderDate], [ClientsAgregatorDB].[Clients].[LastName],
[ClientsAgregatorDB].[Clients].[FirstName], [ClientsAgregatorDB].[Clients].[MiddleName],
[ClientsAgregatorDB].[Orders].[TotalPrice], [ClientsAgregatorDB].[Statuses].[Title],
[ClientsAgregatorDB].[Orders].[OrderReview]
FROM [ClientsAgregatorDB].[Orders]
INNER JOIN [ClientsAgregatorDB].[Clients]
ON [ClientsAgregatorDB].[Orders].[ClientId] = [ClientsAgregatorDB].[Clients].[Id]
INNER JOIN [ClientsAgregatorDB].[Statuses]
ON [ClientsAgregatorDB].[Orders].[StatusesId] = [ClientsAgregatorDB].[Statuses].[Id]