CREATE PROCEDURE [ClientsAgregatorDB].[AddProductOrder]
@OrderId INT,
@ProductId INT,
@Quantity INT
AS
INSERT [ClientsAgregatorDB].[Product_Order]
VALUES (@OrderId, @ProductId, @Quantity)