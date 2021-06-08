CREATE PROCEDURE [ClientsAgregatorDB].[DeleteProductOrderByOrderId]
@OrderId INT
AS
DELETE [ClientsAgregatorDB].[Product_Order]
WHERE OrderId = @OrderId