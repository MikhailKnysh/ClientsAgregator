CREATE PROCEDURE [dbo].[GetClientInfoByProduct]
AS
SELECT [dbo].[Clients].[FirstName],[dbo].[Clients].[MiddleName],[dbo].[Clients].[LastName],
[dbo].[Clients].[Phone],[dbo].[BulkStatus].[Title],
SUM([dbo].[Product_Order].[Quantity]) SUMQuantity,
AVG([dbo].[Feedbacks].[Rate]) AVGRate
FROM [dbo].[Clients] 
JOIN [dbo].[BulkStatus] ON [dbo].[BulkStatus].[Id] = [dbo].[Clients].[BulkStatusId]
JOIN [dbo].[Orders] ON [dbo].[Orders].[ClientId] = [dbo].[Clients].[Id] 
JOIN [dbo].[Product_Order] ON [dbo].[Product_Order].[OrderId] = [dbo].[Orders].[ClientId]
JOIN [dbo].[Products] ON [dbo].[Product_Order].[Id] = [dbo].[Products].[Id]
JOIN [dbo].[Feedbacks] ON [dbo].[Feedbacks].[ProductId] = [dbo].[Products].[Id]
GROUP BY [dbo].[Clients].[FirstName],[dbo].[Clients].[MiddleName],[dbo].[Clients].[LastName],
[dbo].[Clients].[Phone],[dbo].[BulkStatus].[Title],
[dbo].[Product_Order].[Quantity] ,
[dbo].[Feedbacks].[Rate]