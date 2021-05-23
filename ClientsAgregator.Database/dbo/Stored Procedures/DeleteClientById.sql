CREATE PROCEDURE DeleteClientById
@Id INT
AS
DELETE [dbo].[Clients]
WHERE Id = @Id