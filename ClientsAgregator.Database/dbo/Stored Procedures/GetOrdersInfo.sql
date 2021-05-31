CREATE PROCEDURE [dbo].[GetOrdersInfo]
AS
SELECT [dbo].[Orders].[OrderDate], [dbo].[Clients].[LastName],
[dbo].[Clients].[FirstName], [dbo].[Clients].[MiddleName],
[dbo].[Orders].[TotalPrice], [dbo].[Statuses].[Title],
[dbo].[Orders].[OrderReview]
FROM [dbo].[Orders]
INNER JOIN [dbo].[Clients]
ON [dbo].[Orders].[ClientId] = [dbo].[Clients].[Id]
INNER JOIN [dbo].[Statuses]
ON [dbo].[Orders].[StatusesId] = [dbo].[Statuses].[Id]