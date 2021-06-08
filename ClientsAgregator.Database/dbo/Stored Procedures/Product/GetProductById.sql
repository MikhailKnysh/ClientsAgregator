CREATE PROCEDURE [ClientsAgregatorDB].[GetProductById]
@Id INT
AS
SELECT * FROM [ClientsAgregatorDB].[Products]
WHERE Id = @Id

