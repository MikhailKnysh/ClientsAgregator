CREATE PROCEDURE GetProductOrderByProductId
@ProductId INT
AS
SELECT * FROM [dbo].[Product_Order]
WHERE ProductID = @ProductId