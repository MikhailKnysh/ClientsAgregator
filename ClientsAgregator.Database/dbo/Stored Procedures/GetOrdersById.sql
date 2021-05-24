CREATE PROCEDURE GetOrdersById
@Id INT
AS
SELECT * FROM [dbo].[Orders]
WHERE Id = @Id
