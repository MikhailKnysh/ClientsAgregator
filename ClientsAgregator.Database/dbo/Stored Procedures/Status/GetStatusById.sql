CREATE PROCEDURE [ClientsAgregatorDB].[GetStatusById]
@Id int
AS
SELECT * FROM [ClientsAgregatorDB].[Statuses]
WHERE Id = @Id