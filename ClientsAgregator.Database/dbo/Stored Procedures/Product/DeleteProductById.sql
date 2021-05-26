CREATE PROCEDURE DeleteProductById
@Id INT
AS
DELETE [dbo].[Products]
WHERE Id = @Id
