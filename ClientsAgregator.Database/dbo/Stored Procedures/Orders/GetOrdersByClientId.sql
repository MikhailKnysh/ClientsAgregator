CREATE PROCEDURE [ClientsAgregatorDB].[GetOrdersByClientId]
@ClientId INT
AS
SELECT * FROM [ClientsAgregatorDB].[Orders]
WHERE [ClientsAgregatorDB].[Orders].[ClientId] = @ClientId