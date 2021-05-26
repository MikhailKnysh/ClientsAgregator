CREATE PROCEDURE GetProductOrderByOrderId
@OrderId INT
AS
SELECT * FROM [dbo].[Product_Order]
WHERE OrderId = @OrderId