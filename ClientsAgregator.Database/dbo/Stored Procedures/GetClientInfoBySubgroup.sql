CREATE PROCEDURE [ClientsAgregatorDB].[GetClientInfoBySubgroup]
@SubgroupId INT
AS
SELECT [ClientsAgregatorDB].[Clients].[Id] AS ClientId,[ClientsAgregatorDB].[Clients].[LastName], [ClientsAgregatorDB].[Clients].[FirstName],[ClientsAgregatorDB].[Clients].[MiddleName],
[ClientsAgregatorDB].[Clients].[Phone],[ClientsAgregatorDB].[BulkStatus].[Title] AS BulkStatusTitle,
[ClientsAgregatorDB].[Product_Order].[ProductId],[ClientsAgregatorDB].[Products].[Title] AS ProductTitle,
SUM (DISTINCT [ClientsAgregatorDB].[Product_Order].[Quantity])  AS SumQuantity,
AVG ([ClientsAgregatorDB].[Feedbacks].[Rate]) AS AVGRate
FROM [ClientsAgregatorDB].[Clients]
LEFT JOIN [ClientsAgregatorDB].[BulkStatus] ON [ClientsAgregatorDB].[BulkStatus].[Id] = [ClientsAgregatorDB].[Clients].[BulkStatusId]
LEFT JOIN [ClientsAgregatorDB].[Orders] ON [ClientsAgregatorDB].[Clients].[Id] = [ClientsAgregatorDB].[Orders].[ClientId]
LEFT JOIN [ClientsAgregatorDB].[Product_Order] ON [ClientsAgregatorDB].[Orders].[Id] = [ClientsAgregatorDB].[Product_Order].[OrderId]
LEFT JOIN [ClientsAgregatorDB].[Feedbacks] ON [ClientsAgregatorDB].[Clients].[Id] = [ClientsAgregatorDB].[Feedbacks].[ClientId]
LEFT JOIN [ClientsAgregatorDB].[Products] ON [ClientsAgregatorDB].[Products].[Id] = [ClientsAgregatorDB].[Product_Order].[ProductId]
LEFT JOIN [ClientsAgregatorDB].[Product_Subgroup] ON [ClientsAgregatorDB].[Product_Subgroup].ProductId = [ClientsAgregatorDB].[Products].[Id]
WHERE [ClientsAgregatorDB].[Product_Subgroup].[SubgroupId] = @SubgroupId 
GROUP BY [ClientsAgregatorDB].[Clients].[Id],[ClientsAgregatorDB].[Clients].[LastName], [ClientsAgregatorDB].[Clients].[FirstName],[ClientsAgregatorDB].[Clients].[MiddleName],
[ClientsAgregatorDB].[Clients].[Phone],[ClientsAgregatorDB].[BulkStatus].[Title],
[ClientsAgregatorDB].[Product_Order].[ProductId],[ClientsAgregatorDB].[Products].[Title]
