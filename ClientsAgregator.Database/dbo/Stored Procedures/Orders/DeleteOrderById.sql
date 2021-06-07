CREATE PROCEDURE DeleteOrderById
@Id INT
AS
DELETE [dbo].[Orders]
WHERE Id = @Id
