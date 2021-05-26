CREATE PROCEDURE UpdateStatusById
@Id int,
@Title varchar(255)
AS
UPDATE [dbo].[Statuses]
SET
Title = @Title
WHERE Id = @Id