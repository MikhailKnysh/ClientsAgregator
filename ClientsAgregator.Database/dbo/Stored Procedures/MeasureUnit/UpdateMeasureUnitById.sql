CREATE PROCEDURE UpdateMeasureUnitById
@Id INT,
@Title VARCHAR(255)
AS
UPDATE [dbo].[MeasureUnits]
SET
Title = @Title
WHERE Id = @Id