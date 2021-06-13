CREATE PROCEDURE [ClientsAgregatorDB].[GetFeedbacksByOrderId]
@OrderId INT
AS
SELECT * FROM [ClientsAgregatorDB].[Feedbacks]
WHERE OrderId = @OrderId