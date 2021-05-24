CREATE PROCEDURE GetSubgroupById
@Id INT
AS
SELECT * FROM [dbo].[Subgroups]
WHERE Id = @Id