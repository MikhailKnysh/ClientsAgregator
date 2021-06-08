CREATE PROCEDURE DeleteProductById
@productId INT
AS
DELETE [dbo].[Products]
WHERE Id = @productId
