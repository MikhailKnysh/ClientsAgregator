CREATE PROCEDURE [ClientsAgregatorDB].[GetProductOrderByProductId]
@ProductId INT
AS
SELECT * FROM [ClientsAgregatorDB].[Product_Order]
WHERE ProductId = @ProductId