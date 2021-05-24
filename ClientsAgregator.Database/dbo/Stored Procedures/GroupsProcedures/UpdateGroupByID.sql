CREATE PROCEDURE UpdateGroupsById
@Id INT,
@Title VARCHAR(255)
AS
UPDATE [dbo].[Groups]
SET
Title = @Title
WHERE Id = @Id