CREATE PROCEDURE UpdateBulkStatus
@Id INT,
@Title VARCHAR(255)
AS

UPDATE [dbo].[BulkStatus]
SET 
Title = @Title
WHERE Id = @Id