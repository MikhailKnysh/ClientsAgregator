CREATE PROCEDURE GetProductById
@Id INT
AS
SELECT * FROM [dbo].[Products]
WHERE Id = @Id

