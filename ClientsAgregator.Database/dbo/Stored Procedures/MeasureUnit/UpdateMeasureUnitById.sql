CREATE PROCEDURE [ClientsAgregatorDB].[UpdateMeasureUnitById]
@Id INT,
@Title VARCHAR(255)
AS
UPDATE [ClientsAgregatorDB].[MeasureUnits]
SET
Title = @Title
WHERE Id = @Id