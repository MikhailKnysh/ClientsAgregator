CREATE PROCEDURE AddOrder
@ClientId INT,
@StatusesId INT,
@OrderReview VARCHAR(800),
@OrderDate VARCHAR(255),
@TotalPrice FLOAT
AS
INSERT [dbo].[Orders]
OUTPUT inserted.Id
VALUES (@ClientId, @StatusesId, @OrderReview, @OrderDate, @TotalPrice)