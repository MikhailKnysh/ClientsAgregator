CREATE PROCEDURE GetMeasureUnitById
@Id INT
AS
SELECT * FROM [dbo].[MeasureUnits]
WHERE Id = @Id