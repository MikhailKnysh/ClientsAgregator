CREATE PROCEDURE [ClientsAgregatorDB].[DeleteMeasureUnitById]
@Id INT
AS
DELETE [ClientsAgregatorDB].[MeasureUnits]
WHERE Id = @Id