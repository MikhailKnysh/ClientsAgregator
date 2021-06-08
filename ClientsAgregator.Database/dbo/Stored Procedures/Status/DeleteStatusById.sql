CREATE PROCEDURE [ClientsAgregatorDB].[DeleteStatusById]
@Id int
AS
DELETE [ClientsAgregatorDB].[Statuses]
WHERE Id = @Id