CREATE PROCEDURE DeleteProductOrderByCompositId
@OrderId INT,
@ProductId INT
AS
DELETE [dbo].[Product_Order]
WHERE OrderId = @OrderId AND ProductId = @ProductId
exec DeleteProductOrderByOrderId @OrderId
exec DeleteProductOrderByProductId @ProductId