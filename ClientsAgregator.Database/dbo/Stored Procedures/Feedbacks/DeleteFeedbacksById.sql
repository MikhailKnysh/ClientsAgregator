CREATE PROCEDURE [ClientsAgregatorDB].[DeleteFeedbacksById]
@Id INT
AS
DELETE [ClientsAgregatorDB].[Feedbacks]
WHERE Id = @Id