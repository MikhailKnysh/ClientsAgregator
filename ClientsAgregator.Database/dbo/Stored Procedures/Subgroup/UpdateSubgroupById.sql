CREATE PROCEDURE [ClientsAgregatorDB].[UpdateSubgroupById]
@Id INT,
@Title VARCHAR(255)
AS
UPDATE [ClientsAgregatorDB].[Subgroups]
SET
Title = @Title
WHERE Id = @Id