CREATE PROCEDURE [ClientsAgregatorDB].[DeleteProductOrderByProductId]
@ProductId INT
AS
DELETE [ClientsAgregatorDB].[Product_Order]
WHERE ProductId = @ProductId