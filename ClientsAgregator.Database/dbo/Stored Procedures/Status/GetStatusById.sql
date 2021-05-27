CREATE PROCEDURE GetStatusById
@Id int
AS
SELECT * FROM [dbo].[Statuses]
WHERE Id = @Id