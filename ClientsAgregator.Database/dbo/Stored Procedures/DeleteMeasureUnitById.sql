CREATE PROCEDURE DeleteMeasureUnitById
@Id int
AS
DELETE [dbo].[MeasureUnits]
WHERE Id = @Id