CREATE PROCEDURE DeleteGroupById
@Id INT
AS
DELETE [dbo].[Groups]
WHERE Id = @Id