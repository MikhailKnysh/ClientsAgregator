CREATE PROCEDURE [ClientsAgregatorDB].[GetClientInfoByProduct]
@ProductId INT
AS
SELECT [ClientsAgregatorDB].[Clients].[Id] AS [ClientId],[ClientsAgregatorDB].[Clients].[LastName], [ClientsAgregatorDB].[Clients].[FirstName],[ClientsAgregatorDB].[Clients].[MiddleName],
[ClientsAgregatorDB].[Clients].[Phone],[ClientsAgregatorDB].[BulkStatus].[Title] AS BulkStatusTitle,
[ClientsAgregatorDB].[Product_Order].[ProductId],
SUM (DISTINCT [ClientsAgregatorDB].[Product_Order].[Quantity])  AS SumQuantity,
AVG ([ClientsAgregatorDB].[Feedbacks].[Rate]) AS AVGRate
FROM [ClientsAgregatorDB].[Clients]
JOIN [ClientsAgregatorDB].[BulkStatus] ON [ClientsAgregatorDB].[BulkStatus].[Id] = [ClientsAgregatorDB].[Clients].[BulkStatusId]
JOIN [ClientsAgregatorDB].[Orders] ON [ClientsAgregatorDB].[Clients].[Id] = [ClientsAgregatorDB].[Orders].[ClientId]
JOIN [ClientsAgregatorDB].[Product_Order] ON [ClientsAgregatorDB].[Orders].[Id] = [ClientsAgregatorDB].[Product_Order].[OrderId]
JOIN [ClientsAgregatorDB].[Feedbacks] ON [ClientsAgregatorDB].[Clients].[Id] = [ClientsAgregatorDB].[Feedbacks].[ClientId]
WHERE [ClientsAgregatorDB].[Product_Order].[ProductId] = @ProductId
GROUP BY [ClientsAgregatorDB].[Clients].[Id], [Clients].[LastName], [ClientsAgregatorDB].[Clients].[FirstName],[ClientsAgregatorDB].[Clients].[MiddleName],
[ClientsAgregatorDB].[Clients].[Phone],[ClientsAgregatorDB].[BulkStatus].[Title],
[ClientsAgregatorDB].[Product_Order].[ProductId]