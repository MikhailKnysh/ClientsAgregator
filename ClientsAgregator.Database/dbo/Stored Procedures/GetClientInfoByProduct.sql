CREATE PROCEDURE [ClientsAgregatorDB].[GetClientInfoByProduct]
AS
SELECT [ClientsAgregatorDB].[Clients].[LastName], [ClientsAgregatorDB].[Clients].[FirstName],[ClientsAgregatorDB].[Clients].[MiddleName],
[ClientsAgregatorDB].[Clients].[Phone],[ClientsAgregatorDB].[BulkStatus].[Title],
SUM([ClientsAgregatorDB].[Product_Order].[Quantity]) SUMQuantity,
AVG([ClientsAgregatorDB].[Feedbacks].[Rate]) AVGRate
FROM [ClientsAgregatorDB].[Clients] 
JOIN [ClientsAgregatorDB].[BulkStatus] ON [ClientsAgregatorDB].[BulkStatus].[Id] = [ClientsAgregatorDB].[Clients].[BulkStatusId]
JOIN [ClientsAgregatorDB].[Orders] ON [ClientsAgregatorDB].[Orders].[ClientId] = [ClientsAgregatorDB].[Clients].[Id] 
JOIN [ClientsAgregatorDB].[Product_Order] ON [ClientsAgregatorDB].[Product_Order].[OrderId] = [ClientsAgregatorDB].[Orders].[ClientId]
JOIN [ClientsAgregatorDB].[Products] ON [ClientsAgregatorDB].[Product_Order].[Id] = [ClientsAgregatorDB].[Products].[Id]
JOIN [ClientsAgregatorDB].[Feedbacks] ON [ClientsAgregatorDB].[Feedbacks].[ProductId] = [ClientsAgregatorDB].[Products].[Id]
GROUP BY [ClientsAgregatorDB].[Clients].[FirstName],[ClientsAgregatorDB].[Clients].[MiddleName],[ClientsAgregatorDB].[Clients].[LastName],
[ClientsAgregatorDB].[Clients].[Phone],[ClientsAgregatorDB].[BulkStatus].[Title],
[ClientsAgregatorDB].[Product_Order].[Quantity] ,
[ClientsAgregatorDB].[Feedbacks].[Rate]