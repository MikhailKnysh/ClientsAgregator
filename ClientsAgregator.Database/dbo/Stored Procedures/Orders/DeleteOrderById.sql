CREATE PROCEDURE [ClientsAgregatorDB].[DeleteOrderById]
@Id INT
AS
DELETE [ClientsAgregatorDB].[Orders]
WHERE Id = @Id
