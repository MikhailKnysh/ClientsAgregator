CREATE PROCEDURE [ClientsAgregatorDB].[UpdateOrderReviewById]
@Id INT,
@OrderReview VARCHAR(MAX)
AS
UPDATE [ClientsAgregatorDB].[Orders]
SET OrderReview = @OrderReview
WHERE [ClientsAgregatorDB].[Orders].[Id] = @Id