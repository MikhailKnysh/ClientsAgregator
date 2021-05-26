CREATE PROCEDURE DeleteFeedbacksById
@Id INT
AS
DELETE [dbo].[Feedbacks]
WHERE Id = @Id