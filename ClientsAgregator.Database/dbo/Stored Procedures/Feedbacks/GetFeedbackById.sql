CREATE PROCEDURE [ClientsAgregatorDB].[GetFeedbackById]
@Id INT
AS
SELECT * FROM [ClientsAgregatorDB].[Feedbacks]
WHERE Id = @Id
