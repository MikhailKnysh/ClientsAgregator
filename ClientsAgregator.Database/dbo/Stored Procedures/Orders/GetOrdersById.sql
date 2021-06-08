CREATE PROCEDURE [ClientsAgregatorDB].[GetOrdersById]
@Id INT
AS
SELECT * FROM [ClientsAgregatorDB].[Orders]
WHERE Id = @Id
