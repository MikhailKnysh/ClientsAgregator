CREATE PROCEDURE [ClientsAgregatorDB].[UpdateProductOrder]
@OrderId INT,
@ProductId INT,
@Quantity INT
AS
UPDATE [ClientsAgregatorDB].[Product_Order]
SET
OrderId = @OrderId,
ProductId = @ProductId,
Quantity = @Quantity
WHERE OrderId = @OrderId AND ProductId = @ProductId