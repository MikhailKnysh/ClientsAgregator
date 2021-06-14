CREATE PROCEDURE [ClientsAgregatorDB].[GetProductTitles]
AS
SELECT [ClientsAgregatorDB].[Products].[Id], [ClientsAgregatorDB].[Products].[Title]
FROM [ClientsAgregatorDB].[Products]