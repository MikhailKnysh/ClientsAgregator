CREATE PROCEDURE DeleteProductOrderByProductId
@ProductId INT
AS
DELETE [dbo].[Product_Order]
WHERE ProductId = @ProductId