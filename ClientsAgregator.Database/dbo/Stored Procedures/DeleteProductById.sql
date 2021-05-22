CREATE PROCEDURE DeleteProductById
@Id int
AS
DELETE [dbo].[Products]
WHERE Id = @Id
