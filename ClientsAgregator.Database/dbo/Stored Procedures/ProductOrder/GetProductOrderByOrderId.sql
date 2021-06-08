CREATE PROCEDURE [ClientsAgregatorDB].[GetProductOrderByOrderId]
@OrderId INT
AS
SELECT * FROM [ClientsAgregatorDB].[Product_Order]
WHERE OrderId = @OrderId