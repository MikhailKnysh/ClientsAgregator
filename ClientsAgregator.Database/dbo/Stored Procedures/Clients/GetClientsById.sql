CREATE PROCEDURE GetClientsById
@Id INT
AS
SELECT * FROM [dbo].[Clients]
WHERE Id = @Id