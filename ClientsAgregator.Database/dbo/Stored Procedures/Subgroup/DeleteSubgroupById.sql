CREATE PROCEDURE DeleteSubgroupById
@Id INT
AS
DELETE [dbo].[Subgroups]
WHERE Id = @Id