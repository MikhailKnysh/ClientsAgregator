CREATE PROCEDURE UpdateOrderById
@Id INT,
@ClientId INT,
@StatusesId INT,
@SellerComment VARCHAR(800),
@OrderDate VARCHAR(255),
@TotalPrice FLOAT
AS
UPDATE [dbo].[Orders]
SET
ClientId = @ClientId,
StatusesId = @StatusesId,
SellerComment = @SellerComment,
OrderDate = @OrderDate,
TotalPrice = @TotalPrice
WHERE Id = @Id

