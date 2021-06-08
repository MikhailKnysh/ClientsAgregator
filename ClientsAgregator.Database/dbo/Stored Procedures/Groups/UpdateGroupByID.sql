CREATE PROCEDURE [ClientsAgregatorDB].[UpdateGroupsById]
@Id INT,
@Title VARCHAR(255)
AS
UPDATE [ClientsAgregatorDB].[Groups]
SET
Title = @Title
WHERE Id = @Id