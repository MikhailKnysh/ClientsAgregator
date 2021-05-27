CREATE PROCEDURE DeleteMeasureUnitById
@Id INT
AS
DELETE [dbo].[MeasureUnits]
WHERE Id = @Id