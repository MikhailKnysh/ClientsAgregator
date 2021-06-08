CREATE PROCEDURE [ClientsAgregatorDB].[UpdateStatusById]
@Id int,
@Title varchar(255)
AS
UPDATE [ClientsAgregatorDB].[Statuses]
SET
Title = @Title
WHERE Id = @Id