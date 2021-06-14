CREATE PROCEDURE [ClientsAgregatorDB].[GetGroupById]
@Id INT
AS
SELECT * FROM [ClientsAgregatorDB].[Groups]
WHERE Id = @Id