CREATE PROCEDURE UpdateFeedbackById
@Id INT,
@ClientId INT,
@ProductId INT,
@Description VARCHAR(800),
@Date VARCHAR(255),
@Rate INT
AS
UPDATE [dbo].[Feedbacks]
SET
ClientId = @ClientId,
ProductId = @ProductId,
Description = @Description,
Date = @Date,
Rate  = @Rate 
WHERE Id = @Id
