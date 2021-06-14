CREATE PROCEDURE [ClientsAgregatorDB].[DeleteBulkStatus]
@Id INT
AS
DELETE [ClientsAgregatorDB].[BulkStatus]
WHERE Id = @Id
