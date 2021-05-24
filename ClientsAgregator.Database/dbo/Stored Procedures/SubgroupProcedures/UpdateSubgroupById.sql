CREATE PROCEDURE UpdateSubgroupById
@Id INT,
@Title VARCHAR(255)
AS
UPDATE [dbo].[Subgroups]
SET
Title = @Title
WHERE Id = @Id