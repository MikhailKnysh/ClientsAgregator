CREATE PROCEDURE DeleteOrdersById
@Id INT
AS
DELETE [dbo].[Orders]
WHERE Id = @Id
