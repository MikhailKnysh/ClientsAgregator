CREATE PROCEDURE DeleteProductOrderByOrderId
@OrderId INT
AS
DELETE [dbo].[Product_Order]
WHERE OrderId = @OrderId