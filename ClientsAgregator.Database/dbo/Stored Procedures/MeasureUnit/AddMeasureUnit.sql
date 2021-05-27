CREATE PROCEDURE AddMeasureUnit
@Title VARCHAR(255)
AS
INSERT [dbo].[MeasureUnits]
VALUES (@Title)