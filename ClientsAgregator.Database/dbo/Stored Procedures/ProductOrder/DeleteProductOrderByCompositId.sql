CREATE PROCEDURE [ClientsAgregatorDB].[DeleteProductOrderByCompositId]
@OrderId INT,
@ProductId INT
AS
DELETE [ClientsAgregatorDB].[Product_Order]
WHERE OrderId = @OrderId AND ProductId = @ProductId
exec DeleteProductOrderByOrderId @OrderId
exec DeleteProductOrderByProductId @ProductId