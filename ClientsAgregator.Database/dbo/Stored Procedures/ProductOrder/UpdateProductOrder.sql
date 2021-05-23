CREATE PROCEDURE UpdateProductOrder
@OrderId INT,
@ProductId INT,
@Quantity INT
AS
UPDATE [dbo].[Product_Order]
SET
OrderId = @OrderId,
ProductId = @ProductId,
Quantity = @Quantity
WHERE OrderId = @OrderId AND ProductId = @ProductId