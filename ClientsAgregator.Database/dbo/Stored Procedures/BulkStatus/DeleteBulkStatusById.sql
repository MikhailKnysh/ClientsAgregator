CREATE PROCEDURE DeleteBulkStatus
@Id INT
AS
DELETE [dbo].[BulkStatus]
WHERE Id = @Id
