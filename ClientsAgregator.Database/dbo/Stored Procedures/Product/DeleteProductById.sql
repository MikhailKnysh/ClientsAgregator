CREATE PROCEDURE [ClientsAgregatorDB].[DeleteProductById]
@productId INT
AS
UPDATE [ClientsAgregatorDB].[Products]
SET
	[ClientsAgregatorDB].[Products].[IsDeleted] = 'DELETED'
WHERE Id = @productId
