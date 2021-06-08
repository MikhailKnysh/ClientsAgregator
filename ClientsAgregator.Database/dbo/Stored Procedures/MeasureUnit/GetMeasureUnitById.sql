CREATE PROCEDURE [ClientsAgregatorDB].[GetMeasureUnitById]
@Id INT
AS
SELECT * FROM [ClientsAgregatorDB].[MeasureUnits]
WHERE Id = @Id