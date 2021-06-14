CREATE PROCEDURE [ClientsAgregatorDB].[GetSubgroupById]
@Id INT
AS
SELECT * FROM [ClientsAgregatorDB].[Subgroups]
WHERE Id = @Id