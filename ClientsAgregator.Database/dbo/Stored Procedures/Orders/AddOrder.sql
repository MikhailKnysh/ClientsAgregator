CREATE PROCEDURE AddOrder
@ClientId INT,
@StatusesId INT,
@SellerComment VARCHAR(800),
@OrderDate VARCHAR(255),
@TotalPrice FLOAT
AS
INSERT [dbo].[Orders]
VALUES (@ClientId, @StatusesId, @SellerComment, @OrderDate, @TotalPrice)

