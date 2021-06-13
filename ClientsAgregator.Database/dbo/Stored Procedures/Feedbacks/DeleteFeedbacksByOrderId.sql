CREATE PROCEDURE [ClientsAgregatorDB].[DeleteFeedbacksByOrderId]
@OrderId INT
AS
DELETE [ClientsAgregatorDB].[Feedbacks]
WHERE OrderId = @OrderId