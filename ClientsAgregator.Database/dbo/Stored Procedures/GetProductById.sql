CREATE PROCEDURE GetProductById
@Id int
AS
	SELECT * FROM [dbo].[Products]
	WHERE Id = @Id

