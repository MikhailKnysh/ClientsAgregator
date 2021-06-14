CREATE PROCEDURE [ClientsAgregatorDB].[DeleteGroupById]
@Id INT
AS
DELETE [ClientsAgregatorDB].[Groups]
WHERE Id = @Id