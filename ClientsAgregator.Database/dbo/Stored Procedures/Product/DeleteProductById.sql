CREATE PROCEDURE [ClientsAgregatorDB].[DeleteProductById]
@productId INT
AS
DELETE [ClientsAgregatorDB].[Products]
WHERE Id = @productId
