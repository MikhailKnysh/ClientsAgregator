CREATE PROCEDURE GetMeasureUnitById
@Id int
AS
SELECT * FROM [dbo].[MeasureUnits]
WHERE Id = @Id