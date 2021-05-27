CREATE PROCEDURE DeleteStatusById
@Id int
AS
DELETE [dbo].[Statuses]
WHERE Id = @Id