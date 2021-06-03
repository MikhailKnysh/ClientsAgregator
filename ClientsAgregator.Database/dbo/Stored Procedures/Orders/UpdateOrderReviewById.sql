CREATE PROCEDURE [dbo].[UpdateOrderReviewById]
@Id INT,
@OrderReview VARCHAR(MAX)
AS
UPDATE [dbo].[Orders]
SET OrderReview = @OrderReview
WHERE [dbo].[Orders].[Id] = @Id