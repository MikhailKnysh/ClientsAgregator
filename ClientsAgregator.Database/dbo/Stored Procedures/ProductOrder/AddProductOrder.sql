CREATE PROCEDURE [ClientsAgregatorDB].[AddProductOrder]
@OrderId INT,
@ProductId INT,
@Quantity FLOAT
AS
INSERT [ClientsAgregatorDB].[Product_Order]
VALUES (@OrderId, @ProductId, @Quantity)