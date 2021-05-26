CREATE PROCEDURE AddProductOrder
@OrderId INT,
@ProductId INT,
@Quantity INT
AS
INSERT [dbo].[Product_Order]
VALUES (@OrderId, @ProductId, @Quantity)