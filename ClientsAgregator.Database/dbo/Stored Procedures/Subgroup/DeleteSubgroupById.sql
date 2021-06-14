CREATE PROCEDURE [ClientsAgregatorDB].[DeleteSubgroupById]
@Id INT
AS
DELETE [ClientsAgregatorDB].[Subgroups]
WHERE Id = @Id