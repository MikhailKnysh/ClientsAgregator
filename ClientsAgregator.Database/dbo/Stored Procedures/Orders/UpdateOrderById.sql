CREATE PROCEDURE [ClientsAgregatorDB].[UpdateOrderById]
@Id INT,
@ClientId INT,
@StatusesId INT,
@OrderReview VARCHAR(MAX),
@OrderDate VARCHAR(255),
@TotalPrice FLOAT
AS
UPDATE [ClientsAgregatorDB].[Orders]
SET
ClientId = @ClientId,
StatusesId = @StatusesId,
OrderReview = @OrderReview,
OrderDate = @OrderDate,
TotalPrice = @TotalPrice
WHERE Id = @Id

