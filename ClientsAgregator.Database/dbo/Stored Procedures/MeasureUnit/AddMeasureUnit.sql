CREATE PROCEDURE [ClientsAgregatorDB].[AddMeasureUnit]
@Title VARCHAR(255)
AS
INSERT [ClientsAgregatorDB].[MeasureUnits]
VALUES (@Title)