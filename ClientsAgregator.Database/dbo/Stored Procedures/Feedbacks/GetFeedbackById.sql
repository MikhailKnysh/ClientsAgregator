CREATE PROCEDURE [dbo].[GetFeedbackById]
@Id INT
AS
SELECT * FROM [dbo].[Feedbacks]
WHERE Id = @Id
