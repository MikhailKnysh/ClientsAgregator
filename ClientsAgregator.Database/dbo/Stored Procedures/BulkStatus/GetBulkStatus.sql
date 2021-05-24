CREATE PROCEDURE GetBulkStatus
@Id INT
AS

SELECT * FROM [dbo].[BulkStatus]
WHERE Id = @Id
