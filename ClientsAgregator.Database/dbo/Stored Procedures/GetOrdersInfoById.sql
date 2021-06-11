CREATE PROCEDURE [ClientsAgregatorDB].[GetOrdersInfoById]
@Id INT
AS
SELECT [ClientsAgregatorDB].[Orders].[Id], [ClientsAgregatorDB].[Orders].[ClientId],
[ClientsAgregatorDB].[Orders].[StatusesId], [ClientsAgregatorDB].[Orders].[OrderReview],
[ClientsAgregatorDB].[Orders].[OrderDate], [ClientsAgregatorDB].[Orders].[TotalPrice]
FROM [ClientsAgregatorDB].[Orders]
WHERE [ClientsAgregatorDB].[Orders].[Id] = @Id