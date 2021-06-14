CREATE PROCEDURE [ClientsAgregatorDB].[GetProducts]
AS
SELECT * FROM [ClientsAgregatorDB].[Products]
WHERE [ClientsAgregatorDB].[Products].[IsDeleted] IS NULL


