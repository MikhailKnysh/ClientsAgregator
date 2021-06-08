CREATE PROCEDURE [ClientsAgregatorDB].[DeleteClientById]
@Id INT
AS
DELETE [ClientsAgregatorDB].[Clients]
WHERE Id = @Id