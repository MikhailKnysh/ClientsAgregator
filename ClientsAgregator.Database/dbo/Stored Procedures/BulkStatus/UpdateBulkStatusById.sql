CREATE PROCEDURE [ClientsAgregatorDB].[UpdateBulkStatus]
@Id INT,
@Title VARCHAR(255)
AS

UPDATE [ClientsAgregatorDB].[BulkStatus]
SET 
Title = @Title
WHERE Id = @Id