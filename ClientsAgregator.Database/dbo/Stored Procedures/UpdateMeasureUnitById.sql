CREATE PROCEDURE UpdateMeasureUnitById
@Id int,
@Title varchar(255)
AS
UPDATE [dbo].[MeasureUnits]
SET
Title = @Title
WHERE Id = @Id